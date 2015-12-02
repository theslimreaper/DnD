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
	}

	public void AddSpell()
	{
		Character_Info.characterSpells.Add(backgroundID.GetComponent<Text>().text);

		foreach (var item in Character_Info.characterSpells) {
			print(item);
		}
		InfoScreen.SetActive (false);
		spellScreen.SetActive (true);
	}
}

