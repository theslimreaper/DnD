using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;

public class Item_Types : MonoBehaviour {
    public string itemName;
    public int itemCategory;
    public string itemDescr;
    public string itemWeight;
    public string itemCost;
    public int itemPPO;
    public int poisonType;
    public int potionType;
    public int oilType;
    public string poisonOnset;
    public string PPOFortDC;
    public string poisonFrequency;
    public string vehicleMaxSpeed;
    public string vehiclePassengers;
    public string craftHardness;
    public string wpnDmg;
    public int wpnType;
    public string wpnCritRange;
    public string itemProperties;
    public int armorType;
    public string armorDexPenalty;
    public string armorAC;
    public string equipped;


	// Use this for initialization
	void Start () {
        ClearItemFields();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClearItemFields()
    {
        itemName = "";
        itemCategory = 0;
        itemDescr = "";
        itemWeight = "";
        itemCost = "0";
        itemPPO = 0;
        poisonType = 0;
        potionType = 0;
        oilType = 0;
        poisonOnset = "";
        PPOFortDC = "";
        poisonFrequency = "";
        vehicleMaxSpeed = "";
        vehiclePassengers = "";
        craftHardness = "";
        wpnDmg = "";
        wpnType = 0;
        wpnCritRange = "";
        itemProperties = "";
        armorType = 0;
        armorDexPenalty = "";
        armorAC = "";

    }
}
