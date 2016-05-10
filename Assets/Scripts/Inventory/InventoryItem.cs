using System;
using System.Collections;

public class InventoryItem : Object
{
	// Enum of available item types
	public enum ItemTypes
	{
		NONE,
		POTION,
		WEAPON_ONE_HANDED,
		WEAPON_TWO_HANDED,
		ARMOUR_HEAD,
		ARMOUR_BODY,
		ARMOUR_MISC
	}
		
	// Name of this item
	protected string itemName;

	// Description of this item
	protected string itemDescription;

	// What type of item this is (Potion/Weapon/Armour)
	protected ItemTypes itemType;

	// Store Purchase value of the item
	protected int itemCost;

	// Stat values for the item
	protected float attack, defence, speed, luck, health;


	// Read only properties for the above variables
	public string ItemName{ get { return itemName; } }
	public string ItemDescription{ get { return itemDescription; } }
	public ItemTypes ItemType{ get {return itemType; } }
	public int ItemCost{ get { return itemCost; } }

	public float Attack{ get { return attack; } }
	public float Defence{ get { return defence; } }
	public float Speed{ get { return speed; } }
	public float Luck{ get { return luck; } }
	public float Health{ get { return health; } }


	// Item constructor
	public InventoryItem (string name, string description, ItemTypes type, int cost,
		float attack, float defence, float speed, float luck, float health)
	{
		this.itemName = name;
		this.itemDescription = description;
		this.itemType = type;
		this.itemCost = cost;

		this.attack = attack;
		this.defence = defence;
		this.speed = speed;
		this.luck = luck;
		this.health = health;
	}


	// To use this item's special ability
	public virtual void SpecialAbility()
	{
		// Implement special ability here...
	}
}


public class GameItems : Object
{

	// Static array of every available game object
	public static readonly InventoryItem[] gameItems = 
	{
		// Default item (Nothing)

		new InventoryItem(		
			"None",
			"",
			InventoryItem.ItemTypes.NONE,
			0,0,0,0,0,0),


		//Single Handed Weapons

		new InventoryItem(		
			"Wooden Pencil",
			"A long wooden pencil with a pointed graphite tip.",
			InventoryItem.ItemTypes.WEAPON_ONE_HANDED,
			500,6,1,0,1,0),

		new InventoryItem(		
			"Olive Stick",
			"A tooth pick with an olive on top.",
			InventoryItem.ItemTypes.WEAPON_ONE_HANDED,
			200,3,0,1,0,0),


		// Two Handed Weapons

		new InventoryItem(		
			"Plastic Fork",
			"A large 3 pronged plastic table fork.",
			InventoryItem.ItemTypes.WEAPON_TWO_HANDED,
			800,8,2,0,1,0),


		// Armour Head

		new InventoryItem(		
			"Google Eyes",
			"A pair of googly craft eyes.",
			InventoryItem.ItemTypes.ARMOUR_HEAD,
			250,0,2,0,1,0)	,


		// Armour Body

		new InventoryItem(		
			"Fake Mostache",
			"A thick and bushy mostache.",
			InventoryItem.ItemTypes.ARMOUR_BODY,
			200,0,3,0,1,0),


		// Armour Misc

		new InventoryItem(		
			"Eye Patch",
			"An eye patch to look more piratey.",
			InventoryItem.ItemTypes.ARMOUR_MISC,
			400,1,2,0,0,0),
	};

}