using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    Image ItemImage;
    Text ItemText;

    public void Init(Sprite InventoryItem, string InventoryName)
    {
        if(ItemImage == null)
        {
            ItemImage = GetComponent<Image>();
        }

        if (ItemText == null)
        {
            ItemText = GetComponentInChildren<Text>();
        }

        ItemImage.sprite = InventoryItem;
        ItemText.text = InventoryName;
    }
}
