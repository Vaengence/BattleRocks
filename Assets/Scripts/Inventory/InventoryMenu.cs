using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryMenu : MonoBehaviour
{

	[SerializeField]
	private Dropdown slotMenu = null;
	[SerializeField]
	private Dropdown itemMenu = null;

	[SerializeField]
	private Text itemDescription = null;

	[SerializeField]
	private Text itemEquipped = null;

	[SerializeField]
	private Inventory inventoryRef = null;

	// Use this for initialization
	void Start () 
	{
		inventoryRef = Inventory.instance;

		// For Testing only. If inventory is empty, Add some test items and save inventory
//		if (inventoryRef.ItemListCount == 0)
//		{
//			inventoryRef.AddItem <ItemToothPick> ();
//			inventoryRef.AddItem <ItemToothPick> ();
//			inventoryRef.AddItem <ItemPencil> ();
//			inventoryRef.AddItem <ItemPencil> ();
//			inventoryRef.AddItem <ItemFork> ();
//
//			inventoryRef.SaveInventory (true);
//		}

		LoadItemMenu ();
		LoadSlotMenu ();

		OnItemSelect ();
		OnSlotSelect ();
	}


	void LoadItemMenu()
	{

		for (int i = 0; i < inventoryRef.ItemListCount; ++i)
		{
			itemMenu.options.Add (new Dropdown.OptionData (inventoryRef.GetInventoryItem (i).ItemName));
		}

		itemMenu.captionText = itemMenu.captionText; // Force drop down caption refresh
	}
		
	void LoadSlotMenu()
	{

		slotMenu.options.Add (new Dropdown.OptionData ("Weapon Left"));
		slotMenu.options.Add (new Dropdown.OptionData ("Weapon Right"));
		slotMenu.options.Add (new Dropdown.OptionData ("Armour Head"));
		slotMenu.options.Add (new Dropdown.OptionData ("Armour Body"));
		slotMenu.options.Add (new Dropdown.OptionData ("Armour Misc"));

		slotMenu.captionText = slotMenu.captionText; // Force drop down caption refresh
	}


	public void OnItemSelect()
	{
		//Show selected Item stats on screen

		if (inventoryRef.GetInventoryItem (itemMenu.value) != null)
		{
			itemDescription.text = inventoryRef.GetInventoryItem (itemMenu.value).ItemDescription;
		}

	}

	public void OnSlotSelect()
	{
		if (inventoryRef.GetSlotItem ((Inventory.SlotTypes)slotMenu.value) != null)
		{
			itemEquipped.text = inventoryRef.GetSlotItem ((Inventory.SlotTypes)slotMenu.value).ItemName;
		}
		else
		{
			itemEquipped.text = "None";
		}
	}

	public void OnEquipButtonPress()
	{
		if (inventoryRef.GetInventoryItem (itemMenu.value) != null)
		{
			inventoryRef.EquipSlot ((Inventory.SlotTypes)slotMenu.value, inventoryRef.GetInventoryItem (itemMenu.value));
		}

		OnSlotSelect ();

		//Show combined stat values for players equipped items (Attack + 12 etc...)
	}

	public void OnUnEquipButtonPress()
	{
		if (inventoryRef.GetSlotItem ((Inventory.SlotTypes)slotMenu.value) != null)
		{
			inventoryRef.UnEquipSlot ((Inventory.SlotTypes)slotMenu.value);
		}

		OnSlotSelect ();
	}

	public void OnMenuExit()
	{
	inventoryRef.SaveInventory (true);

	}

	// Update is called once per frame
	void Update () 
	{
	
	}

}
