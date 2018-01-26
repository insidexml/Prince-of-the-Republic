using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    public int personalWealth;
    RepublicTown town;
    int counter;
    int ageCounter;

    // Use this for initialization
    void Start()
    {
        counter = 0;
        age = Random.Range(16, 22);
        firstName = "Akihito";
        lastName = "Sanada";
        personalWealth = 100;
        healthLevel = 5;

        town = new RepublicTown();
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter > 500) {    //Quarterly
            town.collectTaxes();
            town.populate();
            grift();
            counter = 0;
            ageCounter++;
        }
        if (ageCounter == 4)
        {
            age++;
            ageCounter = 0;
            healthCheck();
        }
    }

    // Health deteriorates more rapidly over time
    public void healthCheck()
    {
        int healthDrop = Random.Range(0, 100);
        if (age > 50 && age < 60)
        {
            if (healthDrop > 95) { healthLevel--; }
        }
        else if (age > 60 && age < 70)
        {
            if (healthDrop > 80) { healthLevel--; }
        }
        else if (age > 70 && age < 80)
        {
            if (healthDrop > 60) { healthLevel--; }
        }
        else if (age > 80)
        {
            if (healthDrop > 40) { healthLevel -= 2; }
        }
    }

    public void grift()
    {
        personalWealth += (int)(town.treasuryAmount * 0.05);
    }

    public class RepublicTown
    {
        public int treasuryAmount;
        public int population;
        public double birthRate;
        public double deathRate;
        public int populationInflow;
        public int populationOutflow;
        public int townApproval;

        public int townLevel;
        
        public Dictionary<string, Improvement> improvementList = new Dictionary<string, Improvement>();
        
        public RepublicTown() {
            townLevel = 0;
            treasuryAmount = 500;
            population = 100;
            birthRate = 0.1;
            deathRate = 0.05;
            populationInflow = 10;
            populationOutflow = 5;
        }

        public void collectTaxes()
        {
            treasuryAmount += population * 5;
            Debug.Log("Current amount in treasury: " + treasuryAmount);
        }

        public void populate()
        {
            if (townLevel < 1 && population < 500)  // something to keep population growth in check?
            {
                population += (int)(population * (birthRate - deathRate));
                population += populationInflow;
                population -= populationOutflow;
                Debug.Log("Current town population: " + population);
            }
        }
    }
}
