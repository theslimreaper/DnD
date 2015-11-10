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
	// Use this for initialization
	void Start () {
        DisplayMode();
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
    }
}
