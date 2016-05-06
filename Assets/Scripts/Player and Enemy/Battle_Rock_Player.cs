using UnityEngine;
using System.Collections;
using System;

public class Battle_Rock_Player : Base_Rock {

    

    // Use this for initialization
    void Start ()
    {
        cachedY = healthTranform.position.y;
        maxXValue = healthTranform.position.x;
        minXValue = healthTranform.position.x - healthTranform.rect.width;

         
	}
	
	// Update is called once per frame
	void Update ()
    {
    
	}


    //Calculates total damage to enemy based on Stats
    public void Combat()
    {
        GameObject enemy = GameObject.Find("Battle_Rock_Enemy");
        Battle_Rock_Enemy theEnemy = enemy.GetComponent<Battle_Rock_Enemy>();

        finalDamageOutput = (attack - theEnemy.Defense) * (speed / theEnemy.Speed) + luck;
    }

    //Subtracts Enemies Total Damage from current health
    public void ResolveCombat()
    {
        GameObject enemy = GameObject.Find("Battle_Rock_Enemy");
        Battle_Rock_Enemy theEnemy = enemy.GetComponent<Battle_Rock_Enemy>();
        
        this.CurrentHealth -= theEnemy.Damage;
    }

    
}
