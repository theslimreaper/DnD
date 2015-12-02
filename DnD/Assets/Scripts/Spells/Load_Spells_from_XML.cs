using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Load_Spells_from_XML : MonoBehaviour {
	string levelLine;
	string classLine;
	string nameLine;
	string selectedClass = "Wizard";
	public static List<Spell_Class> SpellsZero = new List<Spell_Class>();
	public static List<Spell_Class> SpellsOne = new List<Spell_Class>();
	public static List<Spell_Class> SpellsTwo = new List<Spell_Class>();
	public static List<Spell_Class> SpellsThree = new List<Spell_Class>();
	public static List<Spell_Class> SpellsFour = new List<Spell_Class>();
	public static List<Spell_Class> SpellsFive = new List<Spell_Class>();
	public static List<Spell_Class> SpellsSix = new List<Spell_Class>();
	public static List<Spell_Class> SpellsSeven = new List<Spell_Class>();
	public static List<Spell_Class> SpellsEight = new List<Spell_Class>();
	public static List<Spell_Class> SpellsNine = new List<Spell_Class>();
	public GameObject dropdownValue;
	public RectTransform SpellParentButton;
	static RectTransform SpellParentButtonDefault;
	public RectTransform SpellParentText;
	static RectTransform SpellParentRectDefault;
	static float ParentRectHeight;
	RectTransform ParentRect;
	Scrollbar ScrollBar;
	public GameObject SpellScrollView;
	float screenRatio = (float)Screen.height / (float)1080;
	float screenRatioW = (float)Screen.width / (float)1920;
	public static List<GameObject> dynamicObjects = new List<GameObject>();
	public GameObject Select_Item_Button;
	public GameObject Select_Item_Text;
	public GameObject spellScreen;
	public GameObject InfoScreen;
	public GameObject spellNameObj;
	public GameObject spellLevelObj;
	public GameObject spellCastObj;
	public GameObject spellSchoolObj;
	public GameObject spellDurationObj;
	public GameObject spellRangeObj;
	public GameObject spellClassesObj;
	public GameObject spellDescriptionObj;
	public GameObject spellComponentsObj;
	public GameObject spellRitualObj;
	public GameObject spellRollObj;
	public GameObject spellIDObj;

	// Use this for initialization
	void Start () {
		
		SpellParentButtonDefault = SpellParentButton;
		SpellParentRectDefault = SpellParentButtonDefault.GetComponent<RectTransform>();
		ParentRectHeight = SpellParentRectDefault.rect.height;
		ParentRect = SpellParentRectDefault;
		ScrollBar = SpellScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();

		XML_Loader xmlLoader = ScriptableObject.CreateInstance<XML_Loader> ();//load xml
		List<string> XmlResult  = new List<string> ();
        if (Settings_Screen.is_online == true)
        {
            XmlResult = xmlLoader.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Spells/spells.xml", "spell");
        }
        else
        {
            XmlResult = xmlLoader.LoadInnerXmlFromFile("..\\XML Files/Spells/spells.xml", "spell");
        }

		foreach(var item in XmlResult)//loop through the spell list and sort the spells based off of spell level (if character class is correct)
		{
			classLine = item.Substring(item.IndexOf("<classes>"),(item.IndexOf("</classes>")-item.IndexOf("<classes>")));
			if (classLine.Contains(selectedClass))
			{
				Spell_Class SpellsSet = new Spell_Class();
				SpellsSet.spellName = item.Substring((item.IndexOf("<name>") + 6),((item.IndexOf("</name>")-item.IndexOf("<name>")) - 6));
				SpellsSet.spellLevel = item.Substring(item.IndexOf("<level>") + 7,(item.IndexOf("</level>")-item.IndexOf("<level>")) - 7);
				SpellsSet.spellCast = item.Substring(item.IndexOf("<time>") + 6,(item.IndexOf("</time>")-item.IndexOf("<time>")) - 6);
				SpellsSet.spellClasses = item.Substring(item.IndexOf("<classes>") + 9,(item.IndexOf("</classes>")-item.IndexOf("<classes>")) - 9);
				SpellsSet.spellComponents = item.Substring(item.IndexOf("<components>") + 12,(item.IndexOf("</components>")-item.IndexOf("<components>")) - 12);
				SpellsSet.spellDuration = item.Substring(item.IndexOf("<duration>") + 10,(item.IndexOf("</duration>")-item.IndexOf("<duration>")) - 10);
				SpellsSet.spellRitual = item.Substring(item.IndexOf("<ritual>") + 8,(item.IndexOf("</ritual>")-item.IndexOf("<ritual>")) - 8);
				SpellsSet.spellSchool = item.Substring(item.IndexOf("<school>") + 8,(item.IndexOf("</school>")-item.IndexOf("<school>")) - 8);
				if (item.IndexOf("<roll>") != -1)
				{
					SpellsSet.spellRoll = item.Substring(item.IndexOf("<roll>") + 6,(item.IndexOf("</roll>")-item.IndexOf("<roll>")) - 6);
				}
				SpellsSet.spellRange = item.Substring(item.IndexOf("<range>") + 7,(item.IndexOf("</range>")-item.IndexOf("<range>")) - 7);
				SpellsSet.spellID = item.Substring(item.IndexOf("<id>") + 4,(item.IndexOf("</id>")-item.IndexOf("<id>")) - 4);
				SpellsSet.spellDescription = item.Substring(item.IndexOf("<text> + 6"),(item.IndexOf("</text>")-item.IndexOf("<text>")) - 6);


				levelLine = item.Substring(item.IndexOf("<level>"),(item.IndexOf("</level>")-item.IndexOf("<level>")));
				nameLine = item.Substring(item.IndexOf("<name>"),(item.IndexOf("</name>")-item.IndexOf("<name>")));
				print (levelLine);
				if (levelLine.Contains("0"))
				{
					Load_Spells_from_XML.SpellsZero.Add (SpellsSet);
				}
				else if (levelLine.Contains("1"))
				{
					Load_Spells_from_XML.SpellsOne.Add (SpellsSet);
				}
				else if (levelLine.Contains("2"))
				{
					Load_Spells_from_XML.SpellsTwo.Add (SpellsSet);
				}
				else if (levelLine.Contains("3"))
				{
					Load_Spells_from_XML.SpellsThree.Add (SpellsSet);
				}
				else if (levelLine.Contains("4"))
				{
					Load_Spells_from_XML.SpellsFour.Add (SpellsSet);
				}
				else if (levelLine.Contains("5"))
				{
					Load_Spells_from_XML.SpellsFive.Add (SpellsSet);
				}
				else if (levelLine.Contains("6"))
				{
					Load_Spells_from_XML.SpellsSix.Add (SpellsSet);
				}
				else if (levelLine.Contains("7"))
				{
					Load_Spells_from_XML.SpellsSeven.Add (SpellsSet);
				}
				else if (levelLine.Contains("8"))
				{
					Load_Spells_from_XML.SpellsEight.Add (SpellsSet);
				}
				else if (levelLine.Contains("9"))
				{
					Load_Spells_from_XML.SpellsNine.Add (SpellsSet);
				}
			}
		}
		foreach (var item in Load_Spells_from_XML.SpellsZero) {
			print (item.spellName);
		}
		MakeButtons();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakeButtons()
	{
		List<Spell_Class> SpellsTemp = new List<Spell_Class>();
		int j = 0;

		//DeleteList();
		ScrollBar = SpellScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
		ScrollBar.value = 1;
		if (dropdownValue.GetComponent<Dropdown> ().value == 0) 
		{
			foreach (var item in Load_Spells_from_XML.SpellsZero)
			{
			
			SpellsTemp.Add (item);
			}
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 1)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsOne;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 2)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsTwo;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 3)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsThree;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 4)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsFour;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 5)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsFive;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 6)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsSix;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 7)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsSeven;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 8)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsEight;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 9)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsNine;
		}

		if (SpellParentRectDefault != null)
		{
			ParentRect.sizeDelta = new Vector2(SpellParentRectDefault.rect.width, 0);
			SpellScrollView.transform.position = new Vector3(SpellScrollView.transform.position.x, SpellScrollView.transform.position.y, 250);
			int posBehind = 0;
				for (int i = 0; i < SpellsTemp.Count; i++)
				{
						GameObject ItemButton = (GameObject)Instantiate(Select_Item_Button);
						GameObject itemNameText = ItemButton.gameObject.transform.GetChild(0).gameObject;
						ItemButton.transform.SetParent(SpellParentButton, false);
						ItemButton.transform.localScale = new Vector3(0.18f, 0.1f, 0);
						itemNameText.transform.localScale = new Vector3(1, 1, 1);

						if (j == 0 || j == 1)
						{
							ItemButton.transform.position = new Vector3(SpellParentText.transform.position.x + (j * 150 * screenRatioW), SpellParentText.transform.position.y, 250);
						}
						else
						{
							int mod = j % 2;
							int pos = 0;
							if (mod == 0)
							{
								pos = 0;
								posBehind++;
							}
							else
							{
								pos = 1;
							}
							
							ItemButton.transform.position = new Vector3(SpellParentText.transform.position.x + (pos * 150 * screenRatioW), SpellParentText.transform.position.y - (50 * (j - pos - posBehind) * screenRatio), 250);
						}
						
						dynamicObjects.Add(ItemButton);
						Button tempButton = ItemButton.gameObject.GetComponent<Button>();
						int position = i;
						itemNameText.GetComponent<Text>().text = SpellsTemp[position].spellName;
						tempButton.onClick.AddListener(() => EditMode(position));
						j++;
				}
			}
			
			if (dynamicObjects.Count > 0)
			{
				ParentRect.sizeDelta = new Vector2(SpellParentRectDefault.rect.width, screenRatio * (ParentRectHeight - (dynamicObjects[j - 1].transform.position.y - (dynamicObjects[j - 1].GetComponent<RectTransform>().rect.height))));
				ScrollBar.value = 1;
			}
	}
	
	public void EditMode(int position){

		InfoScreen.SetActive (true);
		spellScreen.SetActive (false);

		List<Spell_Class> SpellsTemp = new List<Spell_Class>();
		
		if (dropdownValue.GetComponent<Dropdown> ().value == 0) 
		{
			foreach (var item in Load_Spells_from_XML.SpellsZero)
			{
				
				SpellsTemp.Add (item);
			}
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 1)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsOne;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 2)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsTwo;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 3)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsThree;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 4)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsFour;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 5)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsFive;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 6)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsSix;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 7)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsSeven;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 8)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsEight;
		}
		else if (dropdownValue.GetComponent<Dropdown> ().value == 9)
		{
			SpellsTemp = Load_Spells_from_XML.SpellsNine;
		}

		spellNameObj.GetComponent<Text>().text = SpellsTemp[position].spellName;
		spellLevelObj.GetComponent<Text>().text = SpellsTemp[position].spellLevel;
		spellCastObj.GetComponent<Text>().text = SpellsTemp[position].spellCast;
		spellSchoolObj.GetComponent<Text>().text = SpellsTemp[position].spellSchool;
		spellDurationObj.GetComponent<Text>().text = SpellsTemp[position].spellDuration;
		spellRangeObj.GetComponent<Text>().text = SpellsTemp[position].spellRange;
		spellClassesObj.GetComponent<Text>().text = SpellsTemp[position].spellClasses;
		spellDescriptionObj.GetComponent<Text>().text = SpellsTemp[position].spellDescription;
		spellComponentsObj.GetComponent<Text>().text = SpellsTemp[position].spellComponents;
		spellRitualObj.GetComponent<Text>().text = SpellsTemp[position].spellRitual;
		spellRollObj.GetComponent<Text>().text = SpellsTemp[position].spellRoll;
		spellIDObj.GetComponent<Text>().text = SpellsTemp[position].spellID;
	}

}

