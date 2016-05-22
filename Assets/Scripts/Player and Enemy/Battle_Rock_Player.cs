using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Battle_Rock_Player : Base_Rock {

    [SerializeField]
    public GameObject enemyRock;

    public Text playerHealthText;

	private float slotAttack, slotDefence, slotSpeed, slotLuck, slotHealth;

	public float SlotDefence{ get { return slotDefence; }}
	public float SlotSpeed { get { return slotSpeed; }}

    // Use this for initialization
    public void Start ()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
        attack = 15;
        defense = 5;
        speed = 2;
        luck = 1;

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

		GetSlotStatTotals ();
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

		finalDamageOutput = ((attack+slotAttack) - enemyRock.GetComponent<Battle_Rock_Enemy>().Defense) * 
			((speed+slotSpeed) / enemyRock.GetComponent<Battle_Rock_Enemy>().Speed) + (luck + slotLuck) + battleRan;
    }

    //Subtracts Enemies Total Damage from current health
    public void ResolveCombat()
    {
        this.CurrentHealth -= enemyRock.GetComponent<Battle_Rock_Enemy>().Damage;
    }

	private void GetSlotStatTotals()
	{
		slotAttack = 0;
		slotDefence = 0;
		slotSpeed =  0;
		slotLuck = 0;
		slotHealth = 0;

		for(int i = 0; i < 5; ++i)
		{
			InventoryItem currentSlot = GameItems.gameItems[Inventory.instance.GetSlotItem ((Inventory.SlotTypes)i)];

			slotAttack += currentSlot.Attack;
			slotDefence += currentSlot.Defence;
			slotSpeed += currentSlot.Speed;
			slotLuck += currentSlot.Luck;
			slotHealth += currentSlot.Health;
		}
	}
}
