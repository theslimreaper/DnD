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


	// Use this for initialization
	void Start () {
        ClearAllFields();
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
}
