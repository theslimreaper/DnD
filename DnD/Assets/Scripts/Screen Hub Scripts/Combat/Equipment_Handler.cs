using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class Equipment_Handler : MonoBehaviour {
    public Dropdown itemCategory;
    public Equipment_Categorizer categorizer;
    public Item_Categorizer itemCategorizer;
    public Equipment_Viewer equipmentViewer;
    static char mode = 'e';
    public GameObject equipButton;
    public GameObject unequipButton;
    public CanvasGroup equipButtonCanvas;
    public CanvasGroup unequipButtonCanvas;
    public GameObject viewer;
    public GameObject selector;
    string equipmentSlot;

	// Use this for initialization
	void Start () {
        CategorizeItems(0);
        HideSelectorAndViewer();
        DisplayMode();
        itemCategory.onValueChanged.AddListener(delegate { CategorizeItems(itemCategory.value); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CategorizeItems(int value)
    {
        int itemCat = 0;
        if(value == 2)
        {
            itemCat = 5;
        }
        else
        {
            itemCat = value;
        }

        categorizer.CategorizeItems(itemCat);
    }

    public void ViewItemDetails(int position)
    {
        int i = position;
        equipmentViewer.SetItemInfo(i, equipmentSlot);
        ShowEquipmentViewer(i);
    }

    public void HideEquipmentViewer()
    {
        equipmentViewer.ClearAllFields();
        viewer.SetActive(false);
        selector.SetActive(true);
        equipmentViewer.newItem = -1;

    }

    public void DisplayMode()
    {
        mode = 'd';
    }

    public void EditMode()
    {
        mode = 'e';
    }

    public void ShowEquipmentViewer(int position)
    {
        viewer.SetActive(true);
        selector.SetActive(false);
        equipmentViewer.ViewMode();
        if (mode == 'd')
        {
            equipButton.SetActive(false);
            equipButtonCanvas.alpha = 0;
            equipButtonCanvas.interactable = false;
            unequipButton.SetActive(false);
            unequipButtonCanvas.alpha = 0;
            unequipButtonCanvas.interactable = false;
        }
        else if (mode == 'e')
        {
            if (Character_Info.characterItems[position].equipped == "")
            {
                equipButton.SetActive(true);
                equipButtonCanvas.alpha = 1;
                equipButtonCanvas.interactable = true;
                unequipButton.SetActive(false);
                unequipButtonCanvas.alpha = 0;
                unequipButtonCanvas.interactable = false;
            }
            else
            {
                equipButton.SetActive(false);
                equipButtonCanvas.alpha = 0;
                equipButtonCanvas.interactable = false;
                unequipButton.SetActive(true);
                unequipButtonCanvas.alpha = 1;
                unequipButtonCanvas.interactable = true;
            }
        }
    }

    public void ShowSelector(string position)
    {
        equipmentSlot = position;
        selector.SetActive(true);
    }

    public void HideSelector()
    {
        equipmentSlot = "";
        selector.SetActive(false);
    }

    public void EquipItem()
    {
        equipmentViewer.EquipItem();
        HideSelectorAndViewer();
        CategorizeItems(itemCategory.value);
        itemCategorizer.CategorizeItems(itemCategorizer.inventoryHandler.itemCategory.value);
    }

    public void UnequipItem()
    {
        equipmentViewer.UnequipItem();
        HideSelectorAndViewer();
        CategorizeItems(itemCategory.value);
        itemCategorizer.CategorizeItems(itemCategorizer.inventoryHandler.itemCategory.value);
    }

    public void HideSelectorAndViewer()
    {
        viewer.SetActive(false);
        selector.SetActive(false);
        equipmentViewer.equipmentSlot = "";
        equipmentSlot = "";
    }
}
