using UnityEngine;
using System.Collections;

public class Armour_Weapon_Sockets : MonoBehaviour {
    
	public GameObject HeadSocket;
    public GameObject MouthSocket;
    public GameObject EyeSocket;
    public GameObject LeftWeaponSocket;
    public GameObject RightWeaponSocket;

	// Use this for initialization
	void Start ()
    {
		//Load Head slot sprite
		string spritePath = GameItems.gameItems[Inventory.instance.GetSlotItem (Inventory.SlotTypes.ARMOUR_HEAD)].ItemSprite;
		HeadSocket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Characters/" + spritePath);

		//Load Body slot sprite
		spritePath = GameItems.gameItems[Inventory.instance.GetSlotItem (Inventory.SlotTypes.ARMOUR_MOUTH)].ItemSprite;
		MouthSocket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Characters/" + spritePath);

		//Load Misc slot sprite
		spritePath = GameItems.gameItems[Inventory.instance.GetSlotItem (Inventory.SlotTypes.ARMOUR_EYE)].ItemSprite;
		EyeSocket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Characters/" + spritePath);

		if (GameItems.gameItems [Inventory.instance.GetSlotItem (Inventory.SlotTypes.WEAPON_LEFT)].ItemType == InventoryItem.ItemTypes.WEAPON_TWO_HANDED)
		{
			//Load two handed weapon slot sprite into the LeftWeaponSlot
			spritePath = GameItems.gameItems [Inventory.instance.GetSlotItem (Inventory.SlotTypes.WEAPON_LEFT)].ItemSprite;
			LeftWeaponSocket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Characters/" + spritePath);

			//Load right weapon slot sprite to null
			RightWeaponSocket.GetComponent<SpriteRenderer> ().sprite = null;
		}
		else
		{
			//Load left weapon slot sprite
			spritePath = GameItems.gameItems [Inventory.instance.GetSlotItem (Inventory.SlotTypes.WEAPON_LEFT)].ItemSprite;
			LeftWeaponSocket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Characters/" + spritePath);

			//Load right weapon slot sprite
			spritePath = GameItems.gameItems [Inventory.instance.GetSlotItem (Inventory.SlotTypes.WEAPON_RIGHT)].ItemSprite;
			RightWeaponSocket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Characters/" + spritePath);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
