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

        cachedY = healthTransform.position.y;
        maxXValue = healthTransform.position.x;
        minXValue = healthTransform.position.x - healthTransform.rect.width;

        maxHealth = 50;
        currentHealth = 25;
        attack = 15;
        defense = 5;
        speed = 2;

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
