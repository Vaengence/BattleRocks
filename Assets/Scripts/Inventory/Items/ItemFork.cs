using System;
using System.Collections;

public class ItemFork : InventoryItem
{
	//Default Constructor
	public ItemFork()
	{
		spriteName = "Fork";
		itemName = "Fork";
		itemDescription = "A large steel fork.\n\n[Weapon : Two Handed]";
		itemType = ItemTypes.WEAPON_TWO_HANDED;
		itemCost = 800;

		attack = 8;
		defence = 2;
		speed = 0;
		luck = 1;
		health = 0;
	}

	// Call to use this item's special ability
	public override void SpecialAbility()
	{
		// Implement special ability here...
	}
}
