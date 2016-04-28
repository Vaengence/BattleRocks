using System;
using System.Collections;

public class ItemPencil : InventoryItem
{
	//Default Constructor
	public ItemPencil()
	{
		spriteName = "Pencil";
		itemName = "Pencil";
		itemDescription = "A long wooden pencil.\n\n[Weapon : Single Handed]";
		itemType = ItemTypes.WEAPON_ONE_HANDED;
		itemCost = 500;

		attack = 6;
		defence = 1;
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
