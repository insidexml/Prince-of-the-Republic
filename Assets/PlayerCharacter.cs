using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    public int personalWealth;
    RepublicTown town;
    int counter;

    // Use this for initialization
    void Start()
    {
        counter = 0;
        age = Random.Range(16, 22);
        firstName = "Akihito";
        lastName = "Sanada";
        personalWealth = 100;

        town = new RepublicTown();
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter > 500) {
            town.collectTaxes();
            town.populate();
            grift();
            counter = 0;
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
        
        public RepublicTown() {
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
            population += (int)(population * (birthRate - deathRate));
            population += populationInflow;
            population -= populationOutflow;
            Debug.Log("Current town population: " + population);
        }
    }
}
