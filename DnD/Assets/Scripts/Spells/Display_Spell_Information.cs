using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Display_Spell_Information : MonoBehaviour
{
	public GameObject InfoScreen;
	public GameObject spellScreen;
	public GameObject backgroundID;
	public GameObject addButton;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void DisplayMode(){
		InfoScreen.SetActive (false);
		spellScreen.SetActive (true);
		addButton.SetActive (true);
	}

	public void AddSpell()
	{
		Character_Info.characterSpells.Add(backgroundID.GetComponent<Text>().text);

		InfoScreen.SetActive (false);
		spellScreen.SetActive (true);
	}
}

