using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Battle_Rock_Player : Base_Rock {

    [SerializeField]
    public GameObject enemyRock;

    public Text playerHealthText;

    // Use this for initialization
    public void Start ()
    {
        maxHealth = 50;
        currentHealth = 25;
        attack = 15;
        defense = 5;
        speed = 2;
        luck = 1;

        cachedY = healthTransform.position.y;
        maxXValue = healthTransform.position.x;
        minXValue = healthTransform.position.x - healthTransform.rect.width;

         
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

//Calculates total damage to enemy based on Stats
public void Combat()
    {
        System.Random battleRandomizer = new System.Random();
        float battleRan = battleRandomizer.Next(-10, 10);

        finalDamageOutput = (attack - enemyRock.GetComponent<Battle_Rock_Enemy>().Defense) * 
                            (speed / enemyRock.GetComponent<Battle_Rock_Enemy>().Speed) + luck + battleRan;
    }

    //Subtracts Enemies Total Damage from current health
    public void ResolveCombat()
    {
        this.CurrentHealth -= enemyRock.GetComponent<Battle_Rock_Enemy>().Damage;
    }

    
}
