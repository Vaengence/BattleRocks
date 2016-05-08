using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

public class StoreManager : MonoBehaviour {

    public ItemButton StoreIconPrefab;

    public Sprite[] ButtonSprites;

    public struct StoreObjectsStruct
    {
        public int StoreItemIndex;
        public string StoreItemImage;
    };

    public StoreObjectsStruct[] StoreObjects;

    // Use this for initialization
    void Start ()
    {
        
        ButtonSprites = Resources.LoadAll<Sprite>("Sprites\\Game\\Character Profile\\Custom Item Icons\\");
        StoreObjects = new StoreObjectsStruct[ButtonSprites.Length];

        for (int i = 0; i < ButtonSprites.Length; i++)
        {
            GameObject Temp = Instantiate(StoreIconPrefab.gameObject, transform.position, transform.rotation) as GameObject;
            Temp.transform.SetParent(transform);

            ItemButton IbTemp = Temp.GetComponent<ItemButton>();
            IbTemp.Init(ButtonSprites[i], StoreObjects[i].StoreItemImage);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
