using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class Inventory_Handler : MonoBehaviour {
    public InputField[] currencies;
    public GameObject displayMode;
    public GameObject editMode;
    public CanvasGroup displayModeCanvas;
    public CanvasGroup editModeCanvas;
    public GameObject addItem;
    public CanvasGroup addItemCanvas;
    public GameObject universalItems;
    public CanvasGroup universalItemsCanvas;
    public Item_Editor itemEditor;
    public Dropdown itemCategory;
    public Item_Categorizer categorizer;
    public Equipment_Handler equipmentHandler;
    static char mode = 'e';
    public GameObject saveButton;
    public GameObject deleteButton;
    public CanvasGroup saveButtonCanvas;
    public CanvasGroup deleteButtonCanvas;
    public Message_Handler MessageBoxYN;
    public Message_Handler MessageBoxOK;

	// Use this for initialization
	void Start () {
        HideItemEditor();
        DisplayMode();
        categorizer.CategorizeItems(0);
        itemCategory.onValueChanged.AddListener(delegate { categorizer.CategorizeItems(itemCategory.value); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DisplayMode()
    {
        for (int i = 0; i < currencies.Length; i++)
        {
            currencies[i].interactable = false;
        }
        displayMode.SetActive(true);
        displayModeCanvas.alpha = 1;
        displayModeCanvas.interactable = true;
        editMode.SetActive(false);
        editModeCanvas.alpha = 0;
        editModeCanvas.interactable = false;
        Character_Info.copper = Convert.ToInt32(currencies[0].text);
        Character_Info.silver = Convert.ToInt32(currencies[1].text);
        Character_Info.electrum = Convert.ToInt32(currencies[2].text);
        Character_Info.gold = Convert.ToInt32(currencies[3].text);
        Character_Info.platinum = Convert.ToInt32(currencies[4].text);
        mode = 'd';

    }

    public void EditMode()
    {
        for(int i = 0; i < currencies.Length; i++)
        {
            currencies[i].interactable = true;
        }
        displayMode.SetActive(false);
        displayModeCanvas.alpha = 0;
        displayModeCanvas.interactable = false;
        editMode.SetActive(true);
        editModeCanvas.alpha = 1;
        editModeCanvas.interactable = true;
        currencies[0].text = Convert.ToString(Character_Info.copper);
        currencies[1].text = Convert.ToString(Character_Info.silver);
        currencies[2].text = Convert.ToString(Character_Info.electrum);
        currencies[3].text = Convert.ToString(Character_Info.gold);
        currencies[4].text = Convert.ToString(Character_Info.platinum);
        mode = 'e';
    }

    public void HideItemEditor()
    {
        addItem.SetActive(false);
        addItemCanvas.alpha = 0;
        addItemCanvas.interactable = false;
        if(mode == 'd')
        {
            displayMode.SetActive(true);
            displayModeCanvas.alpha = 1;
            displayModeCanvas.interactable = true;
        }
        else if (mode == 'e')
        {
            editMode.SetActive(true);
            editModeCanvas.alpha = 1;
            editModeCanvas.interactable = true;
        }
        universalItems.SetActive(true);
        universalItemsCanvas.alpha = 1;
        universalItemsCanvas.interactable = true;
        itemEditor.ClearAllFields();
        itemEditor.newItem = -1;
    }

    public void ShowItemEditor()
    {

        if (mode == 'd')
        {
            itemEditor.ViewMode();
            saveButton.SetActive(false);
            saveButtonCanvas.alpha = 0;
            saveButtonCanvas.interactable = false;
            deleteButton.SetActive(false);
            deleteButtonCanvas.alpha = 0;
            deleteButtonCanvas.interactable = false;
        }
        else if (mode == 'e')
        {
            itemEditor.EditMode();
            saveButton.SetActive(true);
            saveButtonCanvas.alpha = 1;
            saveButtonCanvas.interactable = true;
            if (itemEditor.newItem == -1)
            {
                deleteButton.SetActive(false);
                deleteButtonCanvas.alpha = 0;
                deleteButtonCanvas.interactable = false;
            }
            else
            {
                deleteButton.SetActive(true);
                deleteButtonCanvas.alpha = 1;
                deleteButtonCanvas.interactable = true;
            }
        }
        addItem.SetActive(true);
        addItemCanvas.alpha = 1;
        addItemCanvas.interactable = true;
        editMode.SetActive(false);
        editModeCanvas.alpha = 0;
        editModeCanvas.interactable = false;
        universalItems.SetActive(false);
        universalItemsCanvas.alpha = 0;
        universalItemsCanvas.interactable = false;
    }

    public void SaveItem()
    {
        itemEditor.SaveItemInfo();
        HideItemEditor();
        categorizer.CategorizeItems(itemCategory.value);
        equipmentHandler.CategorizeItems(equipmentHandler.itemCategory.value);
        MessageBoxOK.ShowBox("Save successful!");
    }

    public void DeleteItem()
    {
        MessageBoxYN.ShowBox("Are you sure you want to delete this item?");
        MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => DeleteItemConfirm());
    }

    void DeleteItemConfirm()
    {
        itemEditor.DeleteItem();
        HideItemEditor();
        categorizer.CategorizeItems(itemCategory.value);
        equipmentHandler.CategorizeItems(equipmentHandler.itemCategory.value);
    }

    public void ViewItemDetails(int position)
    {
        int i = position;
        itemEditor.SetItemInfo(i);
        ShowItemEditor();
    }
}
