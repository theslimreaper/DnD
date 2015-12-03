using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpFeatures : MonoBehaviour {
	public string xmlClass;
	public string autolevelString;
	public string currentLevelString;
	public string tempstring;
	int i = 0;
	public List<string> featuresForLevel= new List<string>();
	void Start()
	{
		Character_Info.characterClass = "Barbarian";
		Character_Info.characterLevel = "3";
		FindFeatures ();
	}
	// Update is called once per frame
	public void FindFeatures()
	{
		xmlClass = "<classname>" + Character_Info.characterClass + "</classname>";//look at each class
		XML_Loader xmlLoader = ScriptableObject.CreateInstance<XML_Loader> ();//load xml
		List<string> XmlResult  = new List<string> ();
		
		if(Settings_Screen.is_online==true)//look at setting to determine if you should use online xml or local copy
		{
			XmlResult = xmlLoader.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classes.xml","class" );
		}
		else
		{
			XmlResult = xmlLoader.LoadInnerXmlFromFile("..\\XML Files/Character Features/classes.xml", "class");
		}

		currentLevelString="<autolevel level=\""+Character_Info.characterLevel+"\">";

		foreach(var item in XmlResult)//search through class list to find the players class
		{	
			if(item.Contains(xmlClass))
			{
				print ("end found at: " +item.IndexOf("</autolevel>"));
				autolevelString=item.Substring(	item.IndexOf(currentLevelString),	item.IndexOf("</autolevel>")	);//find all text within autolevel
				break;
			}
		}
		print (autolevelString);
		tempstring = autolevelString;
		while(autolevelString.IndexOf("<feature")!=-1)
		{
			featuresForLevel.Add(autolevelString.Substring(	autolevelString.IndexOf("<feature")	,autolevelString.IndexOf("</feature")+10));//find next <feature>
			print ("feature found: " + featuresForLevel[i]);

			autolevelString=autolevelString.Substring(autolevelString.IndexOf("</feature>")+10);//cut off last used string
			print("remaining string: "+autolevelString);


			print ("next string begins at :"+autolevelString.IndexOf("<feature")+"\nends at: "+autolevelString.IndexOf("</feature"));
			i++;
			if (i>10)
				break;
			                                          
		}

	}
}
