using System;
using System.Collections;

public class ItemToothPick : InventoryItem
{
	//Default Constructor
	public ItemToothPick()
	{
		spriteName = "ToothPick";
		itemName = "Tooth Pick";
		itemDescription = "A small and pointy splint of wood.";
		itemType = ItemTypes.WEAPON_ONE_HANDED;
		itemCost = 200;

		attack = 3;
		defence = 0;
		speed = 1;
		luck = 0;
		health = 0;
	}

	// Call to use this item's special ability
	public override void SpecialAbility()
	{
		// Implement special ability here...
	}
}
