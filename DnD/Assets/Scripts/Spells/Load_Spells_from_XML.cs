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
	public GameObject zeroLevel;
	public GameObject firstLevel;
	public GameObject secondLevel;
	public GameObject thirdLevel;
	public GameObject fourthLevel;
	public GameObject fifthLevel;
	public GameObject sixthLevel;
	public GameObject seventhLevel;
	public GameObject eighthLevel;
	public GameObject ninthLevel;

	// Use this for initialization
	void Start () {
		XML_Loader xmlLoader = ScriptableObject.CreateInstance<XML_Loader> ();//load xml
		List<string> XmlResult  = new List<string> ();
		XmlResult = xmlLoader.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Spells/spells.xml","spell" );

		foreach(var item in XmlResult)//loop through the spell list and sort the spells based off of spell level (if character class is correct)
		{
			classLine = item.Substring(item.IndexOf("<classes>"),(item.IndexOf("</classes>")-item.IndexOf("<classes>")));
			if (classLine.Contains(selectedClass))
			{
				levelLine = item.Substring(item.IndexOf("<level>"),(item.IndexOf("</level>")-item.IndexOf("<level>")));
				nameLine = item.Substring(item.IndexOf("<name>"),(item.IndexOf("</name>")-item.IndexOf("<name>")));
				if (levelLine.Contains("0"))
				{
					zeroLevel.AddComponent<Text>();
					zeroLevel.AddComponent<Button>();
				}
				else if (levelLine.Contains("1"))
				{
					
				}
				else if (levelLine.Contains("2"))
				{
					
				}
				else if (levelLine.Contains("3"))
				{
					
				}
				else if (levelLine.Contains("4"))
				{
					
				}
				else if (levelLine.Contains("5"))
				{
					
				}
				else if (levelLine.Contains("6"))
				{
					
				}
				else if (levelLine.Contains("7"))
				{
					
				}
				else if (levelLine.Contains("8"))
				{
					
				}
				else if (levelLine.Contains("9"))
				{
					
				}
			}
			else
			{
				continue;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}

