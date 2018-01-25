using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

    public string firstName;
    public string lastName;
    public int age;
    public int healthLevel;

    public BaseCharacter(string characterType)
    {
        healthLevel = 5;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
