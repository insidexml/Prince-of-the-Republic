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
        if (counter > 100) {
            town.collectTaxes();
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
        
        public RepublicTown() {
            treasuryAmount = 500;
            population = 100;
        }

        public void collectTaxes()
        {
            treasuryAmount += population * 5;
        }
    }
}
