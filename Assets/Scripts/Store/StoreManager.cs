using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {

    public ItemButton StoreIconPrefab;

    public Sprite[] ItemSprites;
    public string[] ItemNames;

    public Transform StorePanel;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < ItemNames.Length; i++)
        {
            GameObject Temp = Instantiate(StoreIconPrefab.gameObject, transform.position, transform.rotation) as GameObject;
            Temp.transform.SetParent(transform);

            ItemButton IbTemp = Temp.GetComponent<ItemButton>();
            IbTemp.Init(ItemSprites[i], ItemNames[i]);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
