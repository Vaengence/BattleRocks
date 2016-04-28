using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

	public static Inventory instance = null;


	public enum SlotTypes : int
	{
		WEAPON_LEFT = 0,
		WEAPON_RIGHT = 1,
		ARMOUR_HEAD = 2,
		ARMOUR_BODY = 3,
		ARMOUR_MISC = 4
	}
			
	private InventoryItem[] itemSlot = new InventoryItem[5];
	private List<InventoryItem> itemList = new List<InventoryItem>();

	public int ItemListCount{get{return itemList.Count;}}


	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (this.gameObject);

		LoadInventory ();
	}

	// Use this for initialization
	void Start ()
	{
		
	}


	// Looks for an item in the list based on the item's type,
	// and returns the list index to that item if found,  otherwise returns -1
	public int FindItem<T>() where T : InventoryItem
	{

		for (int i = 0; i < itemList.Count; ++i)
		{
			if (typeof(T) == itemList[i].GetType())
			{
				return i;
			}
		}

		return -1;
	}


	// Looks for an item in the list based on the item's type,
	// and returns the list index to that item if found,  otherwise returns -1
	public int FindItem(Type itemType)
	{

		for (int i = 0; i < itemList.Count; ++i)
		{
			if (itemType == itemList[i].GetType())
			{
				return i;
			}
		}

		return -1;
	}


	// Adds an item to the inventory, or increases it's stock by 1 if the item type is already in the inventory.
	public void AddItem<T>() where T : InventoryItem, new()
	{
		int itemIndex = FindItem <T>();

		InventoryItem findItem = null;

		if (itemIndex != -1)
		{
			findItem = itemList [itemIndex];
		}

		if (findItem == null)
		{
			//Add new item if item doesnt already exist in the inventory
			T newItem = new T();
			//= new itemType();
			itemList.Add (newItem);

			newItem.itemStock++;
		}
		else
		{
			findItem.itemStock++;
		}

	}


	// Adds an item to the inventory, or increases it's stock by 1 if the item type is already in the inventory.
	public void AddItem(Type itemType)
	{
		if (itemType.IsSubclassOf(typeof(InventoryItem)) == false)
		{
			return;
		}

		int itemIndex = FindItem (itemType);

		InventoryItem findItem = null;

		if (itemIndex != -1)
		{
			findItem = itemList [itemIndex];
		}

		if (findItem == null)
		{
			//Add new item if item doesnt already exist in the inventory
			InventoryItem newItem = Activator.CreateInstance(itemType) as InventoryItem;
			 //= new itemType();
			itemList.Add (newItem);

			newItem.itemStock++;
		}
		else
		{
			findItem.itemStock++;
		}
			
	}


	// Reduce the item stock amount by 1, and removes the item from the inventory if stock is fully depleted.
	public void DepleteItem(int itemListIndex)
	{
		if (itemListIndex < 0 || itemListIndex >= itemList.Count)
		{
			return;
		}

		itemList [itemListIndex].itemStock--;

		// Remove item if stock is fully depleted
		if (itemList [itemListIndex].itemStock <= 0)
		{
			itemList.RemoveAt (itemListIndex);
		}
	}


	// Removes an item from the inventory, and sorts the list of inventory items
	public void RemoveItem(int itemListIndex)
	{
		if (itemListIndex < 0 || itemListIndex >= itemList.Count)
		{
			return;
		}

		itemList.RemoveAt (itemListIndex);

		itemList.Sort ();
	}


	// Returns a reference to the InventoryItem object at the specified index of the inventory
	public InventoryItem GetInventoryItem(int itemListIndex)
	{
		if (itemListIndex < 0 || itemListIndex >= itemList.Count)
		{
			return null;
		}

		return itemList [itemListIndex];
	}
		

	// Returns a reference to the InventoryItem object in the specified slot
	public InventoryItem GetSlotItem(SlotTypes slotType)
	{

		return itemSlot [(int)slotType];
	}


	// Equips an item to the specified slot
	public void EquipSlot(SlotTypes slotType, InventoryItem item) 
	{

		// Exit the function if item is not an equippable type, if number of item equipped >= item stock,
		// or if the same item is already equipped in the specified slot
		if (item.ItemType == InventoryItem.ItemTypes.POTION || item.numEquipped >= item.itemStock || itemSlot [(int)slotType] == item)
		{
			return;
		}


		//Check whether the slot selected is a weapon slot (Hand)
		if (slotType == SlotTypes.WEAPON_LEFT || slotType == SlotTypes.WEAPON_RIGHT)
		{
			if (item.ItemType == InventoryItem.ItemTypes.WEAPON_ONE_HANDED)
			{
				//Equip slot with a single handed weapon
				UnEquipSlot(slotType);
				itemSlot [(int)slotType] = item;
				itemSlot [(int)slotType].numEquipped++;
			}
			else if (item.ItemType == InventoryItem.ItemTypes.WEAPON_TWO_HANDED)
			{
				// Equip both hands with the same weapon if it's a 2 handed weapon
				UnEquipSlot(SlotTypes.WEAPON_LEFT);
				UnEquipSlot(SlotTypes.WEAPON_RIGHT);

				itemSlot [(int)SlotTypes.WEAPON_LEFT] = item;
				itemSlot [(int)SlotTypes.WEAPON_RIGHT] = item;

				itemSlot [(int)slotType].numEquipped++;
			}
		}
		else
		{
			// Equip the armour if it's compatable with the head/body/misc slot
			if (slotType == SlotTypes.ARMOUR_HEAD && item.ItemType == InventoryItem.ItemTypes.ARMOUR_HEAD)
			{
				UnEquipSlot(slotType);
				itemSlot [(int)slotType] = item;
				itemSlot [(int)slotType].numEquipped++;
			}
			else if (slotType == SlotTypes.ARMOUR_BODY && item.ItemType == InventoryItem.ItemTypes.ARMOUR_BODY)
			{
				UnEquipSlot(slotType);
				itemSlot [(int)slotType] = item;
				itemSlot [(int)slotType].numEquipped++;
			}
			else if (slotType == SlotTypes.ARMOUR_MISC && item.ItemType == InventoryItem.ItemTypes.ARMOUR_MISC)
			{
				UnEquipSlot(slotType);
				itemSlot [(int)slotType] = item;
				itemSlot [(int)slotType].numEquipped++;
			}
		}

	}


	// Removes the item from the specified slot.
	public void UnEquipSlot(SlotTypes slotType)
	{
		if (itemSlot [(int)slotType] != null)
		{
			itemSlot [(int)slotType].numEquipped--;

			// Unequip both hand slots if item is a 2 handed weapon, else unequip specified slot
			if (itemSlot [(int)slotType].ItemType == InventoryItem.ItemTypes.WEAPON_TWO_HANDED)
			{
				itemSlot [(int)SlotTypes.WEAPON_LEFT] = null;
				itemSlot [(int)SlotTypes.WEAPON_RIGHT] = null;
			}
			else
			{
				itemSlot [(int)slotType] = null;
			}
		}
	}

	public void GetSlotStatTotals()
	{

	}

	// Add functionality to load inventory and slots !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	public void LoadInventory()
	{
		int inventoryCount = 0;

		//Check how many inventory items were saved
		if(PlayerPrefs.HasKey("Inventory_Count") == true)
		{
			inventoryCount = PlayerPrefs.GetInt ("Inventory_Count");
		}

		// Load the saved inventory items and add them back to the item list
		for (int i = 0; i < inventoryCount; ++i)
		{
			string itemName = PlayerPrefs.GetString ("ItemType" + i);

			Type itemType = Type.GetType (itemName);

			AddItem(itemType);

			itemList[i].itemStock = PlayerPrefs.GetInt ("ItemStock" + i);
		}

		for (int i = 0; i < itemSlot.Length; ++i)
		{
			string slotItem = PlayerPrefs.GetString ("SlotItem" + i);

			int findIndex = FindItem (Type.GetType (slotItem));

			if (findIndex != -1)
			{
				EquipSlot ((SlotTypes)i, GetInventoryItem (findIndex));
			}
		}

	}

	public void SaveInventory(bool saveToDisk = false)
	{

		//Save how many inventory items there are in the item list
		PlayerPrefs.SetInt ("Inventory_Count", itemList.Count);

		//Save the list of inventory items
		for (int i = 0; i < itemList.Count; ++i)
		{
			PlayerPrefs.SetString ("ItemType" + i, itemList [i].GetType().ToString());

			PlayerPrefs.SetInt ("ItemStock" + i, itemList [i].itemStock);
		}

		//Save which items are equipped
		for (int i = 0; i < itemSlot.Length; ++i)
		{
			if (itemSlot [i] != null)
			{
				PlayerPrefs.SetString ("SlotItem" + i, itemSlot [i].GetType ().ToString ());
			}
		}

		//If true, the data will be saved permanently to the disk, rather than in memory
		if (saveToDisk == true)
		{
			PlayerPrefs.Save ();
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
