using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class InventoryMenu : MonoBehaviour
{

	[SerializeField]
	private ToggleList slotMenu = null;

	[SerializeField]
	private ToggleList itemMenu = null;

	[SerializeField]
	private Text itemDescription = null;

	[SerializeField]
	private Text itemStats = null;

	[SerializeField]
	private Inventory inventoryRef = null;


	// Use this for initialization
	void Start () 
	{
		inventoryRef = Inventory.instance;

		// For Testing only. If inventory is empty, Add some test items and save inventory
		if (inventoryRef.ItemListCount == 0)
		{
			inventoryRef.AddItem <ItemToothPick> ();
			inventoryRef.AddItem <ItemToothPick> ();
			inventoryRef.AddItem <ItemPencil> ();
			inventoryRef.AddItem <ItemPencil> ();
			inventoryRef.AddItem <ItemFork> ();

			inventoryRef.SaveInventory (true);
		}

		LoadItemMenu ();

		OnItemSelect ();
		RefreshSlotText();
	}


	void LoadItemMenu()
	{
		GameObject toggleFirst = Resources.Load("Prefabs/UI_Toggle_Button") as GameObject;

		toggleFirst.GetComponentInChildren<Text> ().text = inventoryRef.GetInventoryItem (0).ItemName;

		for (int i = 0; i < inventoryRef.ItemListCount; ++i)
		{
			GameObject toggleObject = Instantiate (toggleFirst);
			RectTransform toggleRect = toggleObject.transform as RectTransform;

			toggleObject.transform.SetParent (itemMenu.gameObject.transform, false);

			toggleRect.anchoredPosition += new Vector2 (0, -(i*25));

			toggleObject.GetComponentInChildren<Text> ().text = inventoryRef.GetInventoryItem (i).ItemName;

			itemMenu.toggleButtons.Add (toggleObject.GetComponent<Toggle>());
		}
			
		itemMenu.ToggleInit ();
	}


	private string UpdateStats(InventoryItem item)
	{
		string text;

		text = "Stock : " + item.itemStock + "\t|\tEquipped : " + item.numEquipped + "\n";

		text += "\nAttack : \t\t+" + item.Attack;
		text += "\nDefence : \t+" + item.Defence;
		text += "\nSpeed : \t\t+" + item.Speed;
		text += "\nLuck : \t\t\t+" + item.Luck;
		text += "\nHealth : \t\t+" + item.Health;

		return text;
	}

	public void OnItemSelect()
	{
		//Show selected Item stats on screen

		if (inventoryRef.GetInventoryItem (itemMenu.SelectedToggle) != null)
		{
			InventoryItem item = inventoryRef.GetInventoryItem (itemMenu.SelectedToggle);

			itemDescription.text = item.ItemDescription + "\n\n[" + item.ItemType.ToString ().ToLower() + "]";
		}

		itemStats.text = UpdateStats (inventoryRef.GetInventoryItem(itemMenu.SelectedToggle));
	}



	public void RefreshSlotText()
	{

		for (int i = 0; i < slotMenu.toggleButtons.Count; ++i)
		{
			InventoryItem item = inventoryRef.GetSlotItem ((Inventory.SlotTypes)i);

			if(item != null)
			{
				slotMenu.toggleButtons[i].gameObject.GetComponentInChildren<Text> ().text = (Inventory.SlotTypes)i + "\n" + " > " + item.ItemName;
			}
			else
			{
				slotMenu.toggleButtons[i].gameObject.GetComponentInChildren<Text> ().text = (Inventory.SlotTypes)i + "\n" + " > None";
			}

		}
			
	}



	public void OnEquipButtonPress()
	{

		if (inventoryRef.GetInventoryItem (itemMenu.SelectedToggle) != null)
		{
			inventoryRef.EquipSlot ((Inventory.SlotTypes)slotMenu.SelectedToggle, inventoryRef.GetInventoryItem (itemMenu.SelectedToggle));

			RefreshSlotText ();
		}

	}

	public void OnUnEquipButtonPress()
	{
		if (inventoryRef.GetSlotItem ((Inventory.SlotTypes)slotMenu.SelectedToggle) != null)
		{
			inventoryRef.UnEquipSlot ((Inventory.SlotTypes)slotMenu.SelectedToggle);
		}
			
		RefreshSlotText ();
	}

	public void OnMenuExit()
	{
		
	inventoryRef.SaveInventory (true);

	SceneManager.UnloadScene (SceneManager.GetActiveScene ().buildIndex);

	}

	// Update is called once per frame
	void Update () 
	{

	}

}
