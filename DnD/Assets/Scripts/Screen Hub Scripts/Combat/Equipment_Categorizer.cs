using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;

public class Equipment_Categorizer : MonoBehaviour {
    List<Item_Types> itemsViewing = new List<Item_Types>();
    public GameObject Select_Item_Button;
    public GameObject Select_Item_Text;
    public GameObject ScrollView;
    public static List<GameObject> dynamicObjects = new List<GameObject>();
    public RectTransform ParentButton;
    static RectTransform ParentButtonDefault;
    public RectTransform ParentText;
    static RectTransform ParentRectDefault;
    static float ParentRectHeight;
    RectTransform ParentRect;
    float screenRatio = (float)Screen.height / (float)1080;
    float screenRatioW = (float)Screen.width / (float)1920;
    Scrollbar ScrollBar;
    public Equipment_Handler EquipmentHandler;
    public GameObject[] equipment;

    // Use this for initialization
    void Start()
    {
        ParentButtonDefault = ParentButton;
        ParentRectDefault = ParentButtonDefault.GetComponent<RectTransform>();
        ParentRectHeight = ParentRectDefault.rect.height;
        ParentRect = ParentRectDefault;
        ScrollBar = ScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
    }

    public void CategorizeItems(int itemCat)
    {
        int num_of_Items = 0;
        DeleteList();
        foreach (var item in Character_Info.characterItems)
        {
            if (item.itemCategory == itemCat && item.equipped == "")
            {
                num_of_Items++;
            }
        }
        ScrollBar = ScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
        ScrollBar.value = 1;
        if (ParentRectDefault != null)
        {
            int j = 0;
            ParentRect.sizeDelta = new Vector2(ParentRectDefault.rect.width, 0);
            if (num_of_Items > 0)
            {
                num_of_Items = 0;
                foreach (var item in Character_Info.characterItems)
                {
                        num_of_Items++;
                }
                ScrollView.transform.position = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y, 250);
                int posBehind = 0;
                for (int i = 0; i < num_of_Items; i++)
                {
                    if (Character_Info.characterItems[i].itemCategory == itemCat && Character_Info.characterItems[i].equipped == "")
                    {
                        GameObject ItemButton = (GameObject)Instantiate(Select_Item_Button);
                        GameObject itemNameText = ItemButton.gameObject.transform.GetChild(0).gameObject;
                        ItemButton.transform.SetParent(ParentButton, false);
                        ItemButton.transform.localScale = new Vector3(0.18f, 0.1f, 0);
                        itemNameText.transform.localScale = new Vector3(1, 1, 1);
                        itemNameText.GetComponent<Text>().text = PeekAtItemName(i);
                        if (j == 0 || j == 1)
                        {
                            ItemButton.transform.position = new Vector3(ParentText.transform.position.x + (j * 190 * screenRatioW), ParentText.transform.position.y, 250);
                        }
                        else
                        {
                            int mod = j % 2;
                            int pos = 0;
                            if (mod == 0)
                            {
                                pos = 0;
                                posBehind++;
                            }
                            else
                            {
                                pos = 1;
                            }

                            ItemButton.transform.position = new Vector3(ParentText.transform.position.x + (pos * 190 * screenRatioW), ParentText.transform.position.y - (40 * (j - pos - posBehind) * screenRatio), 250);
                        }

                        dynamicObjects.Add(ItemButton);
                        Button tempButton = ItemButton.gameObject.GetComponent<Button>();
                        int position = i;

                        tempButton.onClick.AddListener(() => EquipmentHandler.ViewItemDetails(position));
                        j++;
                    }
                }
            }

            if (dynamicObjects.Count > 0)
            {
                ParentRect.sizeDelta = new Vector2(ParentRectDefault.rect.width, screenRatio * (ParentRectHeight - (dynamicObjects[j - 1].transform.position.y - (dynamicObjects[j - 1].GetComponent<RectTransform>().rect.height))));
                ScrollBar.value = 1;
            }
        }
        int k = 0;
        foreach (var item in Character_Info.characterItems)
        {
            if (Character_Info.characterItems[k].equipped != "")
            {
                int position = k;
                SetEquipment(Convert.ToInt32(Character_Info.characterItems[k].equipped), position);
            }
            k++;
        }
    }

    string PeekAtItemName(int i)
    {
        string text = Character_Info.characterItems[i].itemName;
        return text;
    }

    //Destroy all dynamically created objects for the list
    public void DeleteList()
    {
        foreach (var item in dynamicObjects)
        {
            Destroy(item);
        }

        dynamicObjects.Clear();

        ScrollView.transform.position = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y, -10000);
    }

    void SetEquipment(int slot, int position)
    {
            equipment[slot].GetComponent<Text>().text = Character_Info.characterItems[position].itemName;
    }
	
}
