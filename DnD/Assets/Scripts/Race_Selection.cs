using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Race_Selection : MonoBehaviour {
	
	public GameObject[] racees;
	public GameObject[] raceNames;
	public int transitionSpeed;
	public GameObject raceDescription;
	public CanvasGroup raceDescrCanvasGroup;
	List<string> raceDescrList = new List<string>();
	int moving;

	// Start and Update functions

	void Start () {
		//FormatStartLayout ();
		//Getraces ();
		Application.LoadLevel ("Class Selection");
	}

	void LateUpdate()
	{
		UpdateLayout ();
	}

	//Additional Functions

	//Set initial layout of content
	void FormatStartLayout () 
		{
			for (int i=0; i<racees.Length; i++) {
				var x_pos = ((Screen.width / 2) + (500 * i));
				racees [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
			}
		}
	
	//Update content position based on arrow key presses
	void UpdateLayout()
	{
					if (Input.GetKey (KeyCode.LeftArrow) && racees[racees.Length - 1].transform.position.x >= (Screen.width / 2 )) {
						moving = -1;
					}
					if (Input.GetKey (KeyCode.RightArrow) && racees[0].transform.position.x <= (Screen.width / 2 )) {
						moving = 1;
					}
					if (moving != 0) {
					
						for (int i=0; i<racees.Length; i++) {
							var x_pos = (racees [i].transform.position.x + (moving * 500) * transitionSpeed * Time.deltaTime);
							racees [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
						}
						moving = 0;
					}
		}

	public void ConfirmCharacter()
	{
		Application.LoadLevel ("Base");
	}

	void Getracees()
	{
		List<string> raceNameList = new List<string> ();
		int i = 0;
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		raceNameList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/racesOverview.xml", "racename");
		foreach( var item in raceNameList)
		{
			raceNames[i].GetComponent<Text>().text = item;
			i++;
		}

		raceDescrList = raceNameList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/racesOverview.xml", "description");
	}

	public void Selectrace(int position){
		Character_Info.characterRace = raceNames [position].GetComponent<Text> ().text;
		ConfirmCharacter ();
	}

	public void FillraceDescription(int position)
	{
		StartCoroutine (DescrFadeIn ());
		raceDescription.GetComponent<Text>().text = raceDescrList[position];
	}

	public void ClearraceDescription ()
	{
		StartCoroutine(DescrFadeOut());
		raceDescription.GetComponent<Text> ().text = "";
	}

	IEnumerator DescrFadeIn()
	{
		while (raceDescrCanvasGroup.alpha < 1) {
			raceDescrCanvasGroup.alpha += Time.deltaTime * transitionSpeed * 2;
			yield return null;
		}
		raceDescrCanvasGroup.alpha = 1;
		yield return null;
	}

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