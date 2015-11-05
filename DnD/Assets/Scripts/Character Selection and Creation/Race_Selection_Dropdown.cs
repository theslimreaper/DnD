﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Race_Selection_Dropdown : MonoBehaviour
{

    public GameObject raceDescription;
    public CanvasGroup raceDescrCanvasGroup;
    List<string> raceDescrList = new List<string>();
    List<string> raceNameList = new List<string>();
    public Dropdown raceDropdown;

    // Start and Update functions

    void Start()
    {
        GetRaces();
        foreach (var item in raceNameList)
        {
            raceDropdown.options.Add(new Dropdown.OptionData(item));
        }
        raceDropdown.value = 1;
        raceDropdown.value = 0;
    }

    void LateUpdate()
    {
    }

    //Additional Functions

    //Get the names and decriptions of the races from the xml files
    void GetRaces()
    {
        int i = 0;
        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();
        if (Settings_Screen.is_online == true)
        {
            raceNameList = XML.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/racesOverview.xml", "racename");
        }
        else
        {
            raceNameList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/racesOverview.xml", "racename");
        }

        if (Settings_Screen.is_online == true)
        {
            raceDescrList = XML.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/racesOverview.xml", "racedescription");
        }
        else
        {
            raceDescrList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/racesOverview.xml", "racedescription");
        }
    }

    //Set the character's race and move to the sub race scene
    public void SelectRace()
    {
        Character_Info.characterRace = raceDropdown.options[raceDropdown.value].text;
    }

    //Fill the race description based on the highlighted race
    public void FillRaceDescription(int position)
    {
        raceDescription.GetComponent<Text>().text = raceDescrList[position];
    }

    //Clear the race description
    public void ClearRaceDescription()
    {
        raceDescription.GetComponent<Text>().text = "";
    }

}