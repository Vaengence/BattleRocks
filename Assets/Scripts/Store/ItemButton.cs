using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    Image ItemImage;

    public void Init(Sprite InventoryItem, string StoreItemImage)
    {
        if(ItemImage == null)
        {
            ItemImage = GetComponent<Image>();
        }

        ItemImage.sprite = InventoryItem;
    }
}
