using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Subrace_Selection_Dropdown : MonoBehaviour {
	
	GameObject[] subraces;
	GameObject[] subraceNames;
	public GameObject subraceDescription;
	List<string> subraceDescrList = new List<string>();
	int num_of_subraces = 0;
    public Dropdown subraceDropdown;
	float screenRatioW = (float)Screen.width / (float)1920;
    List<string> subraceNameList = new List<string>();
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Scrollbar scroll;
    public GameObject scrollView;
    public GameObject scrollObj;
    public RacialAbilityScoreFinder RacialAbilityScores;

    // Start and Update functions

    void Start () {
		GetSubraces ();
	}

	void LateUpdate()
	{
	}

	//Additional Functions

	//Get subrace names and descriptions from specified xml file
	public void GetSubraces()
	{
		int i = 0;
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		string subrace_name_tag = Character_Info.characterRace + "name";
		string subrace_descr_tag = Character_Info.characterRace + "descr";
        if (Settings_Screen.is_online == true)
        {
            subraceNameList = XML.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/subracesOverview.xml", subrace_name_tag);
        }
        else
        {
            subraceNameList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/subracesOverview.xml", subrace_name_tag);
        }
		num_of_subraces = i;
		//If there are no subraces then skip to class selection
		if (i == 0) {
			Character_Info.characterSubrace = "";
		}

        if (Settings_Screen.is_online == true)
        {

            subraceDescrList = XML.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/subracesOverview.xml", subrace_descr_tag);
        }
        else
        {
            subraceDescrList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/subracesOverview.xml", subrace_descr_tag);
        }

        SetSubraceOptions();
	}

	//Set character subrace and move to class selection scene
	public void SelectSubrace(){
        Character_Info.characterSubrace = subraceDropdown.options[subraceDropdown.value].text;
        FillSubraceDescription();
        RacialAbilityScores.FindRacialModifiers();
	}

	//Fill sub race description based on highlighted subrace
	public void FillSubraceDescription()
	{
        if (Character_Info.characterSubrace != "")
        {
            subraceDescription.GetComponent<Text>().text = subraceDescrList[subraceDropdown.value];
            scrollView.SetActive(true);
            if (subraceDescription.GetComponent<RectTransform>().rect.height < scrollView.GetComponent<RectTransform>().rect.height)
            {
                scrollObj.SetActive(false);
            }
            else
            {
                scrollObj.SetActive(true);
            }
            scroll.value = 1;
        }
        else
        {
            subraceDescription.GetComponent<Text>().text = "";
            scrollView.SetActive(false);
        }
	}

	//Clear subrace description
	public void ClearSubraceDescription ()
	{
		subraceDescription.GetComponent<Text> ().text = "";
	}

    public void SetSubraceOptions()
    {
        subraceDropdown.options.Clear();
        foreach (var item in subraceNameList)
        {
            subraceDropdown.options.Add(new Dropdown.OptionData(item));
        }
        if (subraceDropdown.options.Count == 0)
        {
            subraceDropdown.options.Add(new Dropdown.OptionData(""));
            subraceDropdown.interactable = false;

        }
        else
        {
            subraceDropdown.interactable = true;
        }
        subraceDropdown.onValueChanged.RemoveAllListeners();
        subraceDropdown.value = 1;
        subraceDropdown.value = 0;
        SelectSubrace();
        subraceDropdown.onValueChanged.AddListener(delegate { audioSource.PlayOneShot(audioClip); });
        subraceDropdown.onValueChanged.AddListener(delegate { SelectSubrace(); });
    }
}