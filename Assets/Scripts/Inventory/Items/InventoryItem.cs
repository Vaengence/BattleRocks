using System;
using System.Collections;

public abstract class InventoryItem : Object
{
	// Enum of available item types
	public enum ItemTypes
	{
		POTION,
		WEAPON_ONE_HANDED,
		WEAPON_TWO_HANDED,
		ARMOUR_HEAD,
		ARMOUR_BODY,
		ARMOUR_MISC
	}


	public int itemStock;
	public int numEquipped;


	// Asset name for this item's sprite
	protected string spriteName;

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
	public string SpriteName{ get { return spriteName; } }

	public string ItemName{ get { return itemName; } }
	public string ItemDescription{ get { return itemDescription; } }
	public ItemTypes ItemType{ get {return itemType; } }

	public int ItemCost{ get { return itemCost; } }

	public float Attack{ get { return attack; } }
	public float Defence{ get { return defence; } }
	public float Speed{ get { return speed; } }
	public float Luck{ get { return luck; } }
	public float Health{ get { return health; } }


	// To use this item's special ability
	public virtual void SpecialAbility()
	{
		// Implement special ability here...
	}
}
