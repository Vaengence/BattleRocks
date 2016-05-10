using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Battle_Rock_Enemy : Base_Rock {

    [SerializeField]
    public GameObject playerRock;

    public Text enemyHealthText;

    // Use this for initialization
    public void Start ()
    {

        

        maxHealth = 50;
        currentHealth = maxHealth;
        attack = 15;
        defense = 5;
        speed = 2;

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    void Update()
    {
        
    }


    public void Combat()
    {
        System.Random battleRandomizer = new System.Random();
        float battleRan = battleRandomizer.Next(-10, 10);

        finalDamageOutput = (attack - playerRock.GetComponent<Battle_Rock_Player>().Defense) *
                            (speed / playerRock.GetComponent<Battle_Rock_Player>().Speed) + luck + battleRan;

    }

    public void ResolveCombat()
    {
        this.CurrentHealth -= playerRock.GetComponent<Battle_Rock_Player>().Damage;
    }
}
