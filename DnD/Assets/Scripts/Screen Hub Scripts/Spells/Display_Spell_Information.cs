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
	public CanvasGroup[] screenCanvasGroups;

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
		screenCanvasGroups[0].alpha = 1;
		screenCanvasGroups[0].interactable = true;
	}
	
	public void AddSpell()
	{
		bool valid = true;
		bool range = true;
		if (Character_Info.characterClass.Contains("Bard")) {
			if (Character_Info.characterLevel == "0")
			{
				int i = 0;
				int j = 0;
				foreach(var spell in Load_Spells_from_ID.SpellsZero)
				{
					if(spell.spellLevel == "0")
					{
						j++;
					}
					i++;
				}
				if (i > 4)
				{
					valid = false;
				}
				else if (j > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "1")
			{
				int i = 0;
				int j = 0;
				int k = 0;
				foreach(var spell in Load_Spells_from_ID.SpellsOne)
				{
					if(spell.spellLevel == "0")
					{
						j++;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					i++;
				}
				if (i > 4)
				{
					valid = false;
				}
				else if (j > 2 || k > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "2")
			{
				int i = 0;
				int j = 0;
				int k = 0;
				foreach(var spell in Load_Spells_from_ID.SpellsTwo)
				{
					if(spell.spellLevel == "0")
					{
						j++;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					i++;
				}
				if (i > 5)
				{
					valid = false;
				}
				else if (j > 2)
				{
					valid = false;
				}
				else if (k > 3)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "3")
			{
				int i = 0;
				int j = 0;
				int k = 0;
				int l = 0;
				foreach(var spell in Load_Spells_from_ID.SpellsThree)
				{
					if(spell.spellLevel == "0")
					{
						j++;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					i++;
				}
				if (i > 5)
				{
					valid = false;
				}
				else if (j > 2 || l > 2)
				{
					valid = false;
				}
				else if (k > 4)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "4")
			{
				
			}
			else if (Character_Info.characterLevel == "5")
			{
				
			}
			else if (Character_Info.characterLevel == "6")
			{
				
			}
			else if (Character_Info.characterLevel == "7")
			{
				
			}
			else if (Character_Info.characterLevel == "8")
			{
				
			}
			else if (Character_Info.characterLevel == "9")
			{
				
			}
			else if (Character_Info.characterLevel == "10")
			{
				
			}
			else if (Character_Info.characterLevel == "11")
			{
				
			}
			else if (Character_Info.characterLevel == "12")
			{
				
			}
			else if (Character_Info.characterLevel == "13")
			{
				
			}
			else if (Character_Info.characterLevel == "14")
			{
				
			}
			else if (Character_Info.characterLevel == "15")
			{
				
			}
			else if (Character_Info.characterLevel == "16")
			{
				
			}
			else if (Character_Info.characterLevel == "17")
			{
				
			}
			else if (Character_Info.characterLevel == "18")
			{
				
			}
			else if (Character_Info.characterLevel == "19")
			{
				
			}
			else if (Character_Info.characterLevel == "20")
			{
				
			}
		}
		if (Character_Info.characterClass.Contains("Cleric")) {
			if (Character_Info.characterLevel == "0")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "1")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "2")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "3")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "4")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "5")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "6")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1"  && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "7")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "8")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "9")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4" && spellLevel.GetComponent<Text>().text != "5")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "10")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4" && spellLevel.GetComponent<Text>().text != "5")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "11")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4" && spellLevel.GetComponent<Text>().text != "5" && spellLevel.GetComponent<Text>().text != "6")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "12")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4" && spellLevel.GetComponent<Text>().text != "5" && spellLevel.GetComponent<Text>().text != "6")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "13")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4" && spellLevel.GetComponent<Text>().text != "5" && spellLevel.GetComponent<Text>().text != "6" && spellLevel.GetComponent<Text>().text != "7")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "14")
			{
				if (spellLevel.GetComponent<Text>().text != "0" && spellLevel.GetComponent<Text>().text != "1" && spellLevel.GetComponent<Text>().text != "2" && spellLevel.GetComponent<Text>().text != "3" && spellLevel.GetComponent<Text>().text != "4" && spellLevel.GetComponent<Text>().text != "5" && spellLevel.GetComponent<Text>().text != "6" && spellLevel.GetComponent<Text>().text != "7")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "15")
			{
				if (spellLevel.GetComponent<Text>().text == "9")
				{
					range = false;
				}
			}
			else if (Character_Info.characterLevel == "16")
			{
				if (spellLevel.GetComponent<Text>().text == "9")
				{
					range = false;
				}
			}
		}
		if (Character_Info.characterClass.Contains("Druid")) {
			if (Character_Info.characterLevel == "0")
			{

			}
			else if (Character_Info.characterLevel == "1")
			{
				
			}
			else if (Character_Info.characterLevel == "2")
			{
				
			}
			else if (Character_Info.characterLevel == "3")
			{
				
			}
			else if (Character_Info.characterLevel == "4")
			{
				
			}
			else if (Character_Info.characterLevel == "5")
			{
				
			}
			else if (Character_Info.characterLevel == "6")
			{
				
			}
			else if (Character_Info.characterLevel == "7")
			{
				
			}
			else if (Character_Info.characterLevel == "8")
			{
				
			}
			else if (Character_Info.characterLevel == "9")
			{
				
			}
			else if (Character_Info.characterLevel == "10")
			{
				
			}
			else if (Character_Info.characterLevel == "11")
			{
				
			}
			else if (Character_Info.characterLevel == "12")
			{
				
			}
			else if (Character_Info.characterLevel == "13")
			{
				
			}
			else if (Character_Info.characterLevel == "14")
			{
				
			}
			else if (Character_Info.characterLevel == "15")
			{
				
			}
			else if (Character_Info.characterLevel == "16")
			{
				
			}
			else if (Character_Info.characterLevel == "17")
			{
				
			}
			else if (Character_Info.characterLevel == "18")
			{
				
			}
			else if (Character_Info.characterLevel == "19")
			{
				
			}
			else if (Character_Info.characterLevel == "20")
			{
				
			}
		}

		if (valid == true && range == true) {
			Character_Info.characterSpells.Add (backgroundID.GetComponent<Text> ().text);

			InfoScreen.SetActive (false);
			spellScreen.SetActive (true);
			screenCanvasGroups [0].alpha = 1;
			screenCanvasGroups [0].interactable = true;
		}
		else if (valid == false) {
			print ("cannot have that many spells known");
		}
		if (range == false) {
			print ("level range is invalid");
		}
	}
}

