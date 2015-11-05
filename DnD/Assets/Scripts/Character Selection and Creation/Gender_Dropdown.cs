using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gender_Dropdown : MonoBehaviour {
    public Dropdown genderDropdown;
	// Use this for initialization
	void Start () {
        SelectGender();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectGender()
    {
        Character_Info.characterGender = genderDropdown.options[genderDropdown.value].text;
    }
}
