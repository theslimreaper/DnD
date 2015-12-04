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
		List<Spell_Class> SpellsTemp = new List<Spell_Class>();
		foreach (var spell in Load_Spells_from_ID.SpellsZero) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsOne) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsTwo) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsThree) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsFour) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsFive) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsSix) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsSeven) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsEight) {
			SpellsTemp.Add(spell);
		}
		foreach (var spell in Load_Spells_from_ID.SpellsNine) {
			SpellsTemp.Add(spell);
		}
		bool valid = true;
		bool range = true;
		if (Character_Info.characterClass.Contains("Bard")) {
			if (Character_Info.characterLevel == "0")
			{
				int i = 1;
				int j = 1;
				foreach(var spell in SpellsTemp)
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
				int i = 1;
				int j = 1;
				int k = 1;
				foreach(var spell in SpellsTemp)
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
				int i = 1;
				int j = 1;
				int k = 1;
				foreach(var spell in SpellsTemp)
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
				else if (j > 2 || k > 3)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "3")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				foreach(var spell in SpellsTemp)
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
				if (i > 6)
				{
					valid = false;
				}
				else if (j > 2 || k > 4 || l > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "4")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				foreach(var spell in SpellsTemp)
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
				if (i > 7)
				{
					valid = false;
				}
				else if (j > 3 || k > 4 || l > 3)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "5")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					i++;
				}
				if (i > 8)
				{
					valid = false;
				}
				else if (j > 3 || k > 4 || l > 3 || m > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "6")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					i++;
				}
				if (i > 9)
				{
					valid = false;
				}
				else if (j > 3 || k > 4 || l > 3 || m > 3)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "7")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					i++;
				}
				if (i > 10)
				{
					valid = false;
				}
				else if (j > 3 || k > 4 || l > 3 || m > 3 || n > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "8")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					i++;
				}
				if (i > 11)
				{
					valid = false;
				}
				else if (j > 3 || k > 4 || l > 3 || m > 3 || n > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "9")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					i++;
				}
				if (i > 12)
				{
					valid = false;
				}
				else if (j > 3 || k > 4 || l > 3 || m > 3 || n > 3 || o > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "10")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					i++;
				}
				if (i > 14)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "11")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					i++;
				}
				if (i > 15)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "12")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					i++;
				}
				if (i > 15)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "13")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					i++;
				}
				if (i > 16)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "14")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					i++;
				}
				if (i > 18)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "15")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					i++;
				}
				if (i > 19)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1 || r > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "16")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					i++;
				}
				if (i > 19)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1 || r > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "17")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 20)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1 || r > 1 || s > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "18")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 22)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 3 || p > 1 || q > 1 || r > 1 || s > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "19")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 22)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 3 || p > 2 || q > 1 || r > 1 || s > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "20")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
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
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 22)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 3 || m > 3 || n > 3 || o > 3 || p > 2 || q > 2 || r > 1 || s > 1)
				{
					valid = false;
				}
			}
		}

		if (Character_Info.characterClass.Contains("Sorcerer")) {
			if (Character_Info.characterLevel == "0")
			{
				int i = 1;
				int j = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					i++;
				}
				if (i > 4)
				{
					valid = false;
				}
				else if (j > 4)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "1")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					i++;
				}
				if (i > 2)
				{
					valid = false;
				}
				else if (j > 4 || k > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "2")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					i++;
				}
				if (i > 3)
				{
					valid = false;
				}
				else if (j > 4 || k > 3)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "3")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
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
				if (i > 4)
				{
					valid = false;
				}
				else if (j > 4 || k > 4 || l > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "4")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
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
				else if (j > 5 || k > 4 || l > 3)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "5")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					i++;
				}
				if (i > 6)
				{
					valid = false;
				}
				else if (j > 5 || k > 4 || l > 3 || m > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "6")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					i++;
				}
				if (i > 7)
				{
					valid = false;
				}
				else if (j > 5 || k > 4 || l > 3 || m > 3)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "7")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					i++;
				}
				if (i > 8)
				{
					valid = false;
				}
				else if (j > 5 || k > 4 || l > 3 || m > 3 || n > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "8")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					i++;
				}
				if (i > 9)
				{
					valid = false;
				}
				else if (j > 5 || k > 4 || l > 3 || m > 3 || n > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "9")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					i++;
				}
				if (i > 10)
				{
					valid = false;
				}
				else if (j > 5 || k > 4 || l > 3 || m > 3 || n > 3 || o > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "11")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					i++;
				}
				if (i > 11)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "11")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					i++;
				}
				if (i > 12)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "12")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					i++;
				}
				if (i > 12)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "13")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					i++;
				}
				if (i > 13)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "14")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					i++;
				}
				if (i > 13)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "15")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					i++;
				}
				if (i > 14)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1 || r > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "16")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					i++;
				}
				if (i > 14)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1 || r > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "17")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 15)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 2 || p > 1 || q > 1 || r > 1 || s > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "18")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 15)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 3 || p > 1 || q > 1 || r > 1 || s > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "19")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 15)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 3 || p > 2 || q > 1 || r > 1 || s > 1)
				{
					valid = false;
				}
			}
			else if (Character_Info.characterLevel == "20")
			{
				int i = 1;
				int j = 1;
				int k = 1;
				int l = 1;
				int m = 1;
				int n = 1;
				int o = 1;
				int p = 1;
				int q = 1;
				int r = 1;
				int s = 1;
				foreach(var spell in SpellsTemp)
				{
					if(spell.spellLevel == "0")
					{
						j++;
						i--;
					}
					else if (spell.spellLevel == "1")
					{
						k++;
					}
					else if (spell.spellLevel == "2")
					{
						l++;
					}
					else if (spell.spellLevel == "3")
					{
						m++;
					}
					else if (spell.spellLevel == "4")
					{
						n++;
					}
					else if (spell.spellLevel == "5")
					{
						o++;
					}
					else if (spell.spellLevel == "6")
					{
						p++;
					}
					else if (spell.spellLevel == "7")
					{
						q++;
					}
					else if (spell.spellLevel == "8")
					{
						r++;
					}
					else if (spell.spellLevel == "9")
					{
						s++;
					}
					i++;
				}
				if (i > 15)
				{
					valid = false;
				}
				else if (j > 6 || k > 4 || l > 3 || m > 3 || n > 3 || o > 3 || p > 2 || q > 2 || r > 1 || s > 1)
				{
					valid = false;
				}
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

