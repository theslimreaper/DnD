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
	public GameObject universalButtons;
	public CanvasGroup universalCanvas;

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
		universalButtons.SetActive (true);
		universalCanvas.alpha = 1;
		universalCanvas.interactable = true;
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

		if (valid == true && range == true) {
			Character_Info.characterSpells.Add (backgroundID.GetComponent<Text> ().text);

			DisplayMode ();
		}
		else if (valid == false) {
			print ("cannot have that many spells known");
		}
		if (range == false) {
			print ("level range is invalid");
		}
	}
}

