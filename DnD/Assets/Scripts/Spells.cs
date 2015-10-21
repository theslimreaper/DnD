﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spells : MonoBehaviour {
	public List<string> spells = new List<string>();

	// Use this for initialization
	void Start () {
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
        
        if(Settings_Screen.is_online == true)
        {
		spells = XML.LoadXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Spells/spells.xml", "spell");
        }
        else
        {
            spells = XML.LoadInnerXmlFromFile("..\\XML Files/Spells/spells.xml", "spell");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
