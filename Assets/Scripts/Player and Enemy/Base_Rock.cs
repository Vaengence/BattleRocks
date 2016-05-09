using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public abstract class Base_Rock : MonoBehaviour {

    protected float attack, defense, speed, luck, maxHealth, currentHealth;
    protected float finalDamageOutput;

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            HandleHealth();
        }
    }

    

    protected string rockName;
    protected string rockDescription;

    protected string SpriteID;


    public float Defense{get { return defense; }}
    public float Speed { get { return speed; } }
    public float Damage { get { return finalDamageOutput; } }

    //Entire Health Bar Sprite
    public Slider healthBar;
    //The Coloured Part of the Health Bar
    public Image Fill;
    public Color maxHealthColour = Color.green;
    public Color minHealthColour = Color.red;

	
	// Update is called once per frame
	void Update ()
    {
     
	}

    

    //Changes the Position and the Colour of the health bar
    //Depending on the Player's current health
    protected void HandleHealth()
    {
        healthBar.value = currentHealth;
        Fill.color = Color.Lerp(minHealthColour, maxHealthColour, 
                               (float)currentHealth / maxHealth);

    }

}
