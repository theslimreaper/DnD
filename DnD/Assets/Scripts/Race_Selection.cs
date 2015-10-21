using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Race_Selection : MonoBehaviour {
	
	public GameObject[] races;
	public GameObject[] raceNames;
	public int transitionSpeed;
	public GameObject raceDescription;
	public CanvasGroup raceDescrCanvasGroup;
	List<string> raceDescrList = new List<string>();
	int moving;
	float screenRatioW = (float)Screen.width / (float)1920;

	// Start and Update functions

	void Start () {
		FormatStartLayout ();
		GetRaces ();
	}

	void LateUpdate()
	{
		UpdateLayout ();
	}

	//Additional Functions

	//Set initial layout of content
	void FormatStartLayout () 
		{
			for (int i=0; i<races.Length; i++) {
				var x_pos = ((Screen.width / 2) + (500 * i * screenRatioW));
				races [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
			}
		}
	
	//Update content position based on arrow key presses
	void UpdateLayout()
	{
		if (Input.GetKey (KeyCode.LeftArrow) && races[0].transform.position.x <= (Screen.width / 2 )) {
						moving = 1;
					}
		if (Input.GetKey (KeyCode.RightArrow) && races[races.Length - 1].transform.position.x >= (Screen.width / 2 )) {
						moving = -1;
					}
					if (moving != 0) {
					
						for (int i=0; i<races.Length; i++) {
							var x_pos = (races [i].transform.position.x + (moving * 500 * screenRatioW) * transitionSpeed * Time.deltaTime);
							races [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
						}
						moving = 0;
					}
		}

	//Get the names and decriptions of the races from the xml files
	void GetRaces()
	{
		List<string> raceNameList = new List<string> ();
		int i = 0;
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
        if(Settings_Screen.is_online == true)
        {
		raceNameList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/racesOverview.xml", "racename");
        }
        else
        {
            raceNameList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/racesOverview.xml", "racename");
        }
		foreach( var item in raceNameList)
		{
			raceNames[i].GetComponent<Text>().text = item;
			i++;
		}

        if(Settings_Screen.is_online == true)
        {
		raceDescrList  = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/racesOverview.xml", "racedescription");
        }
        else
        {
            raceDescrList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/racesOverview.xml", "racedescription");
        }
	}

	//Set the character's race and move to the sub race scene
	public void SelectRace(int position){
		Character_Info.characterRace = raceNames [position].GetComponent<Text> ().text;
		Application.LoadLevel ("Subrace Selection");
	}

	//Fill the race description based on the highlighted race
	public void FillRaceDescription(int position)
	{
		StartCoroutine (DescrFadeIn ());
		raceDescription.GetComponent<Text>().text = raceDescrList[position];
	}

	//Clear the race description
	public void ClearRaceDescription ()
	{
		StartCoroutine(DescrFadeOut());
		raceDescription.GetComponent<Text> ().text = "";
	}

	//Bring the race description into view
	IEnumerator DescrFadeIn()
	{
		while (raceDescrCanvasGroup.alpha < 1) {
			raceDescrCanvasGroup.alpha += Time.deltaTime * transitionSpeed * 2;
			yield return null;
		}
		raceDescrCanvasGroup.alpha = 1;
		yield return null;
	}

	//Take the race decription out of view
	IEnumerator DescrFadeOut()
	{
		while (raceDescrCanvasGroup.alpha > 0) {
			raceDescrCanvasGroup.alpha -= Time.deltaTime * transitionSpeed * 2;
			yield return null;
		}
		raceDescrCanvasGroup.alpha = 0;
		yield return null;
	}

}