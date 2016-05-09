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

    protected float cachedY;
    protected float minXValue;
    protected float maxXValue;

    protected string rockName;
    protected string rockDescription;

    protected string SpriteID;


    public float Defense{get { return defense; }}
    public float Speed { get { return speed; } }
    public float Damage { get { return finalDamageOutput; } }

    //Entire Health Bar Sprite
    public RectTransform healthTransform;
    //The Coloured Part of the Health Bar
    

    public Image visualHealth;
	
	// Update is called once per frame
	void Update ()
    {
     
	}

    //Calculates what position to move the Health Bar
    //Depending on what the players current health is
    protected float MapValues(float a_maxHealth, float a_currentHealth, float a_minXPos, float a_maxXPos)
    {
        float tempVal = (a_currentHealth / a_maxHealth);

        return (a_maxXPos - Math.Abs(a_minXPos)) * tempVal;
    }

    //Changes the Position and the Colour of the health bar
    //Depending on the Player's current health
    protected void HandleHealth()
    {
        //healthText.text = "Health: " + (int)currentHealth;

        float currentXValue = MapValues(maxHealth, currentHealth, minXValue, maxXValue);

        visualHealth.transform.position = new Vector3(currentXValue, cachedY);
        

        if (currentHealth > maxHealth / 2)
        {
            visualHealth.color = new Color32((byte)MapValues(maxHealth / 2, currentHealth, 255, 0), 255, 0, 255);
        }
        else
        {
            visualHealth.color = new Color32(255, (byte)MapValues(currentHealth, maxHealth / 2, 0, 255), 0, 255);
        }

    }

}
