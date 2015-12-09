using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Load_Feats_from_ID : MonoBehaviour {
	string idLine;
	string nameLine;
	public static List<Feat_Class> FeatsList = new List<Feat_Class>();
	public RectTransform FeatParentButton;
	static RectTransform FeatParentButtonDefault;
	public RectTransform FeatParentText;
	static RectTransform FeatParentRectDefault;
	static float ParentRectHeight;
	RectTransform ParentRect;
	Scrollbar ScrollBar;
	public GameObject FeatScrollView;
	float screenRatio = (float)Screen.height / (float)1080;
	float screenRatioW = (float)Screen.width / (float)1920;
	public static List<GameObject> dynamicObjects = new List<GameObject>();
	public GameObject Select_Item_Button;
	public GameObject Select_Item_Text;
	public GameObject featScreen;
	public GameObject InfoScreen;
	public GameObject featNameObj;
	public GameObject featModifierObj;
	public GameObject featDescriptionObj;
	public GameObject featPrereqObj;
	public GameObject featIDObj;
	
	// Use this for initialization
	public void Start () {
        FeatsList.Clear();
		FeatParentButtonDefault = FeatParentButton;
		FeatParentRectDefault = FeatParentButtonDefault.GetComponent<RectTransform>();
		ParentRectHeight = FeatParentRectDefault.rect.height;
		ParentRect = FeatParentRectDefault;
		ScrollBar = FeatScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
		
		XML_Loader xmlLoader = ScriptableObject.CreateInstance<XML_Loader> ();//load xml
		List<string> XmlResult  = new List<string> ();
        if (Settings_Screen.is_online == true)
        {
            XmlResult = xmlLoader.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character Features/feats.xml", "feat");
        }
        else
        {
            XmlResult = xmlLoader.LoadInnerXmlFromFile("..\\XML Files/Character Features/feats.xml", "feat");
        }
		List<string> IDList = new List<string> ();
		foreach (var item in Character_Info.characterFeats) {
			IDList.Add(item);
		}
		string IDContained = "";
		
		foreach(var item in XmlResult)//loop through the spell list and sort the spells based off of spell level (if character class is correct)
		{
			foreach (var IDItem in IDList) {
				IDContained = IDItem;
				idLine = item.Substring(item.IndexOf("<id>") + 4,(item.IndexOf("</id>")-item.IndexOf("<id>")) - 4);
				if (idLine.Contains(IDContained))
				{
					Feat_Class FeatsSet = new Feat_Class();
					FeatsSet.featName = item.Substring((item.IndexOf("<name>") + 6),((item.IndexOf("</name>")-item.IndexOf("<name>")) - 6));
					FeatsSet.featPrereq = item.Substring(item.IndexOf("<prerequisite>") + 14,(item.IndexOf("</prerequisite>")-item.IndexOf("<prerequisite>")) - 14);
					if (item.IndexOf("<modifier>") != -1)
					{
						FeatsSet.featModifier = item.Substring(item.IndexOf("<modifier>") + 10,(item.IndexOf("</modifier>")-item.IndexOf("<modifier>")) - 10);
					}
					FeatsSet.featID = item.Substring(item.IndexOf("<id>") + 4,(item.IndexOf("</id>")-item.IndexOf("<id>")) - 4);
					
					FeatsSet.featDescription = item.Substring(item.IndexOf("<text>") + 6,(item.IndexOf("</text>")-item.IndexOf("<text>")) - 6);
					nameLine = item.Substring(item.IndexOf("<name>") + 6,(item.IndexOf("</name>")-item.IndexOf("<name>")) - 6);
					bool newfeat = true;
					foreach (var feat in FeatsList)
					{
						if (feat.featID == IDContained)
						{
							newfeat = false;
						}

					}

					if (newfeat == true)
					{
						FeatsList.Add (FeatsSet);
					}
				}
			}
		}
		MakeButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void MakeButtons()
	{
		List<Feat_Class> FeatsTemp = new List<Feat_Class>();
		int j = 0;
		
		DeleteList();
		ScrollBar = FeatScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
		ScrollBar.value = 1;
		FeatsTemp = Load_Feats_from_ID.FeatsList;
		
		if (FeatParentRectDefault != null)
		{
			ParentRect.sizeDelta = new Vector2(FeatParentRectDefault.rect.width, 0);
			FeatScrollView.transform.position = new Vector3(FeatScrollView.transform.position.x, FeatScrollView.transform.position.y, 250);
			int posBehind = 0;
			for (int i = 0; i < FeatsTemp.Count; i++)
			{
				GameObject ItemButton = (GameObject)Instantiate(Select_Item_Button);
				GameObject itemNameText = ItemButton.gameObject.transform.GetChild(0).gameObject;
				ItemButton.transform.SetParent(FeatParentButton, false);
				ItemButton.transform.localScale = new Vector3(0.18f, 0.1f, 0);
				itemNameText.transform.localScale = new Vector3(1, 1, 1);
				
				if (j == 0 || j == 1)
				{
					ItemButton.transform.position = new Vector3(FeatParentText.transform.position.x + (j * 150 * screenRatioW), FeatParentText.transform.position.y, 250);
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
					
					ItemButton.transform.position = new Vector3(FeatParentText.transform.position.x + (pos * 150 * screenRatioW), FeatParentText.transform.position.y - (50 * (j - pos - posBehind) * screenRatio), 250);
				}

				dynamicObjects.Add(ItemButton);
				Button tempButton = ItemButton.gameObject.GetComponent<Button>();
				int position = i;
				itemNameText.GetComponent<Text>().text = FeatsTemp[position].featName;
				tempButton.onClick.AddListener(() => EditMode(position));
				j++;
			}
		}
		
		if (dynamicObjects.Count > 0)
		{
			ParentRect.sizeDelta = new Vector2(FeatParentRectDefault.rect.width, screenRatio * (ParentRectHeight - (dynamicObjects[j - 1].transform.position.y - (dynamicObjects[j - 1].GetComponent<RectTransform>().rect.height))));
			ScrollBar.value = 1;
		}
	}
	
	public void EditMode(int position){
		
		InfoScreen.SetActive (true);
		featScreen.SetActive (false);
		
		List<Feat_Class> FeatsTemp = new List<Feat_Class>();
		FeatsTemp = Load_Feats_from_ID.FeatsList;
		
		featNameObj.GetComponent<Text>().text = FeatsTemp[position].featName;
		featModifierObj.GetComponent<Text>().text = FeatsTemp[position].featModifier;
		featIDObj.GetComponent<Text>().text = FeatsTemp[position].featID;
		featDescriptionObj.GetComponent<Text>().text = FeatsTemp[position].featDescription;
		featPrereqObj.GetComponent<Text>().text = FeatsTemp[position].featPrereq;
	}

	public void DeleteList()
	{
		foreach (var item in dynamicObjects)
		{
			Destroy(item);
		}
		
		dynamicObjects.Clear();
		
		FeatScrollView.transform.position = new Vector3(FeatScrollView.transform.position.x, FeatScrollView.transform.position.y, -10000);
	}
	
}

