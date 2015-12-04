using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpFeatures : MonoBehaviour {
	public string xmlClass;
	public string autolevelString;
	string currentLevelString;
	public string tempstring;
	int i = 0;
	public List<string> XmlResult=new List<string>();
	public List<string> featuresForLevel= new List<string>();
	public List<string> featuresNames= new List<string>();
	public List<string> featuresDescriptions=new List<string>();
	public List<GameObject> selectedFeats = new List<GameObject> ();
	public GameObject listedFeature;
	public GameObject DropDownContent;
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
		XmlResult  = new List<string> ();
		
		if(Settings_Screen.is_online==true)//look at setting to determine if you should use online xml or local copy
		{
			XmlResult = xmlLoader.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classes.xml",Character_Info.characterClass.Substring (0, 4)+"autolevel" );
		}
		else
		{
			XmlResult = xmlLoader.LoadInnerXmlFromFile("..\\XML Files/Character Features/classes.xml",Character_Info.characterClass.Substring (0, 4).ToLower()+"autolevel");
		}

		currentLevelString = XmlResult [System.Convert.ToInt32 (Character_Info.characterLevel)];
		int i=0;
		while(currentLevelString.IndexOf("<feature")!=-1)//features still in string
		{
			currentLevelString=currentLevelString.Substring(currentLevelString.IndexOf("<feature"));
			featuresForLevel.Add(currentLevelString.Substring(0,currentLevelString.IndexOf("</feature>")));
			featuresNames.Add (featuresForLevel[i].Substring(featuresForLevel[i].IndexOf("<name>")+6,featuresForLevel[i].IndexOf("</name>")-featuresForLevel[i].IndexOf("<name>")-6));
			featuresDescriptions.Add (featuresForLevel[i].Substring(featuresForLevel[i].IndexOf("<text>")+6,featuresForLevel[i].IndexOf("</text>")-featuresForLevel[i].IndexOf("<text>")-6));
			currentLevelString=currentLevelString.Substring(currentLevelString.IndexOf("</feature"));
			i++;
		}

		i = 0;
		foreach(string name in featuresNames)
		{
			GameObject item=Instantiate(listedFeature,new Vector3(listedFeature.transform.position.x,listedFeature.transform.position.y-80*i,listedFeature.transform.position.z),Quaternion.identity)as GameObject;
			item.transform.SetParent(DropDownContent.transform);
			item.transform.localScale=new Vector3(1,1,1);
			item.transform.localPosition.Set(60,listedFeature.transform.position.y-27*i,0);
			foreach( Transform child in item.transform)
			{
				if(child.name=="Label")
				{
					child.GetComponent<Text>().text=featuresNames[i];
				}
			}
			selectedFeats.Add (item);
			item.GetComponent<LevelUpClassFeaturePopup>().title=featuresNames[i];
			item.GetComponent<LevelUpClassFeaturePopup>().Description=featuresDescriptions[i];
			i++;
		}
		listedFeature.SetActive (false);
	}

	public void FeaturesPageDone()
	{
		foreach(GameObject item in selectedFeats)
		{
			if(!item.GetComponent<Toggle>().isOn)//remove feats that werent picked
			{
				selectedFeats.Remove(item);
			}
		}

		foreach(GameObject item in selectedFeats)
		{
			Character_Info.characterClassFeaturesNames.Add (item.GetComponent<LevelUpClassFeaturePopup>().title);
			Character_Info.characterClassFeaturesNames.Add (item.GetComponent<LevelUpClassFeaturePopup>().Description);
		}
		Application.LoadLevel ("Screen Hub");
	}
}
