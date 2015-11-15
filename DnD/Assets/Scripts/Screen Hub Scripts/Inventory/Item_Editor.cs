using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;

public class Item_Editor : MonoBehaviour {
    public GameObject itemName;
    public GameObject itemCategory;
    public GameObject itemDescr;
    public GameObject itemWeight;
    public GameObject itemCost;
    public GameObject itemPPO;
    public GameObject poisonType;
    public GameObject potionType;
    public GameObject oilType;
    public GameObject poisonOnset;
    public GameObject PPOFortDC;
    public GameObject poisonFrequency;
    public GameObject vehicleMaxSpeed;
    public GameObject vehiclePassengers;
    public GameObject craftHardness;
    public GameObject wpnDmg;
    public GameObject wpnType;
    public GameObject wpnCritRange;
    public GameObject itemProperties;
    public GameObject armorType;
    public GameObject armorDexPenalty;
    public GameObject armorAC;
    public int newItem;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClearPPOFields()
    {
        poisonType.transform.GetChild(0).GetComponent<Dropdown>().value = 0;
        poisonOnset.transform.GetChild(0).GetComponent<InputField>().text = "";
        poisonFrequency.transform.GetChild(0).GetComponent<InputField>().text = "";
        potionType.transform.GetChild(0).GetComponent<Dropdown>().value = 0;
        oilType.transform.GetChild(0).GetComponent<Dropdown>().value = 0;
    }

    public void ClearAllFields()
    {
        ClearPPOFields();
        ClearNonUniversalFields();
        itemName.transform.GetChild(0).GetComponent<InputField>().text = "";
        itemDescr.transform.GetChild(0).GetComponent<InputField>().text = "";
        itemWeight.transform.GetChild(0).GetComponent<InputField>().text = "";
        itemCost.transform.GetChild(0).GetComponent<InputField>().text = "";
        itemCategory.transform.GetChild(0).GetComponent<Dropdown>().value = 0;
    }

    public void ClearNonUniversalFields()
    {
        PPOFortDC.transform.GetChild(0).GetComponent<InputField>().text = "";
        itemPPO.transform.GetChild(0).GetComponent<Dropdown>().value = 0;
        craftHardness.transform.GetChild(0).GetComponent<InputField>().text = "";
        wpnDmg.transform.GetChild(0).GetComponent<InputField>().text = "";
        wpnCritRange.transform.GetChild(0).GetComponent<InputField>().text = "";
        wpnType.transform.GetChild(0).GetComponent<Dropdown>().value = 0;
        armorDexPenalty.transform.GetChild(0).GetComponent<InputField>().text = "";
        armorAC.transform.GetChild(0).GetComponent<InputField>().text = "";
        armorType.transform.GetChild(0).GetComponent<Dropdown>().value = 0;
        itemProperties.transform.GetChild(0).GetComponent<InputField>().text = "";
        vehicleMaxSpeed.transform.GetChild(0).GetComponent<InputField>().text = "";
        vehiclePassengers.transform.GetChild(0).GetComponent<InputField>().text = "";
    }

    public void SaveItemInfo()
    {
        Item_Types savedItem = new Item_Types();

        savedItem.PPOFortDC = PPOFortDC.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.itemPPO = itemPPO.transform.GetChild(0).GetComponent<Dropdown>().value;
        savedItem.craftHardness = craftHardness.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.wpnDmg = wpnDmg.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.wpnCritRange = wpnCritRange.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.wpnType = wpnType.transform.GetChild(0).GetComponent<Dropdown>().value;
        savedItem.armorDexPenalty = armorDexPenalty.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.armorAC = armorAC.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.armorType = armorType.transform.GetChild(0).GetComponent<Dropdown>().value;
        savedItem.itemProperties = itemProperties.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.vehicleMaxSpeed = vehicleMaxSpeed.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.vehiclePassengers = vehiclePassengers.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.itemName = itemName.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.itemDescr = itemDescr.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.itemWeight = itemWeight.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.itemCost = itemCost.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.itemCategory = itemCategory.transform.GetChild(0).GetComponent<Dropdown>().value;
        savedItem.poisonType = poisonType.transform.GetChild(0).GetComponent<Dropdown>().value;
        savedItem.poisonOnset = poisonOnset.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.poisonFrequency = poisonFrequency.transform.GetChild(0).GetComponent<InputField>().text;
        savedItem.potionType = potionType.transform.GetChild(0).GetComponent<Dropdown>().value;
        savedItem.oilType = oilType.transform.GetChild(0).GetComponent<Dropdown>().value;
        if(newItem == -1)
        {
            Character_Info.characterItems.Add(savedItem);
        }
        else
        {
            Character_Info.characterItems[newItem] = savedItem;
        }

    }

    public void DeleteItem()
    {
        Character_Info.characterItems.RemoveAt(newItem);
    }

    public void ViewMode()
    {
        PPOFortDC.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        itemPPO.transform.GetChild(0).GetComponent<Dropdown>().interactable = false;
        craftHardness.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        wpnDmg.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        wpnCritRange.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        wpnType.transform.GetChild(0).GetComponent<Dropdown>().interactable = false;
        armorDexPenalty.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        armorAC.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        armorType.transform.GetChild(0).GetComponent<Dropdown>().interactable = false;
        itemProperties.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        vehicleMaxSpeed.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        vehiclePassengers.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        itemName.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        itemDescr.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        itemWeight.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        itemCost.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        itemCategory.transform.GetChild(0).GetComponent<Dropdown>().interactable = false;
        poisonType.transform.GetChild(0).GetComponent<Dropdown>().interactable = false;
        poisonOnset.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        poisonFrequency.transform.GetChild(0).GetComponent<InputField>().interactable = false;
        potionType.transform.GetChild(0).GetComponent<Dropdown>().interactable = false;
        oilType.transform.GetChild(0).GetComponent<Dropdown>().interactable = false;
    }

    public void EditMode()
    {
        PPOFortDC.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        itemPPO.transform.GetChild(0).GetComponent<Dropdown>().interactable = true;
        craftHardness.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        wpnDmg.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        wpnCritRange.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        wpnType.transform.GetChild(0).GetComponent<Dropdown>().interactable = true;
        armorDexPenalty.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        armorAC.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        armorType.transform.GetChild(0).GetComponent<Dropdown>().interactable = true;
        itemProperties.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        vehicleMaxSpeed.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        vehiclePassengers.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        itemName.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        itemDescr.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        itemWeight.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        itemCost.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        itemCategory.transform.GetChild(0).GetComponent<Dropdown>().interactable = true;
        poisonType.transform.GetChild(0).GetComponent<Dropdown>().interactable = true;
        poisonOnset.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        poisonFrequency.transform.GetChild(0).GetComponent<InputField>().interactable = true;
        potionType.transform.GetChild(0).GetComponent<Dropdown>().interactable = true;
        oilType.transform.GetChild(0).GetComponent<Dropdown>().interactable = true;
    }

    public void SetItemInfo(int position)
    {
        PPOFortDC.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].PPOFortDC;
        itemPPO.transform.GetChild(0).GetComponent<Dropdown>().value = Character_Info.characterItems[position].itemPPO;
        wpnDmg.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].wpnDmg;
        wpnCritRange.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].wpnCritRange;
        wpnType.transform.GetChild(0).GetComponent<Dropdown>().value = Character_Info.characterItems[position].wpnType;
        armorDexPenalty.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].armorDexPenalty;
        armorAC.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].armorAC;
        armorType.transform.GetChild(0).GetComponent<Dropdown>().value = Character_Info.characterItems[position].armorType;
        itemProperties.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].itemProperties;
        vehicleMaxSpeed.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].vehicleMaxSpeed;
        vehiclePassengers.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].vehiclePassengers;
        itemName.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].itemName;
        itemDescr.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].itemDescr;
        itemWeight.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].itemWeight;
        itemCost.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].itemCost;
        itemCategory.transform.GetChild(0).GetComponent<Dropdown>().value = Character_Info.characterItems[position].itemCategory;
        poisonType.transform.GetChild(0).GetComponent<Dropdown>().value = Character_Info.characterItems[position].poisonType;
        poisonOnset.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].poisonOnset;
        poisonFrequency.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].poisonFrequency;
        potionType.transform.GetChild(0).GetComponent<Dropdown>().value = Character_Info.characterItems[position].potionType;
        oilType.transform.GetChild(0).GetComponent<Dropdown>().value = Character_Info.characterItems[position].oilType;
        craftHardness.transform.GetChild(0).GetComponent<InputField>().text = Character_Info.characterItems[position].craftHardness;
        newItem = position;
    }
}
