using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Subrace_Selection : MonoBehaviour {
	
	public GameObject[] subraces;
	public GameObject[] subraceNames;
	public int transitionSpeed;
	public GameObject subraceDescription;
	public CanvasGroup subraceDescrCanvasGroup;
	List<string> subraceDescrList = new List<string>();
	int moving;
	int num_of_subraces = 0;

	// Start and Update functions

	void Start () {
		GetSubraces ();
		FormatStartLayout ();
	}

	void LateUpdate()
	{
		UpdateLayout ();
	}

	//Additional Functions

	//Set initial layout of content
	void FormatStartLayout () 
		{
			for (int i=0; i<subraceNames.Length; i++) {
				var x_pos = ((Screen.width / 2) + (500 * i));
				subraces [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
			}
			for (int i=num_of_subraces; i<subraces.Length; i++) {
				subraces [i].SetActive(false);
			}
		}
	
	//Update content position based on arrow key presses
	void UpdateLayout()
	{
					if (Input.GetKey (KeyCode.LeftArrow) && subraces[num_of_subraces - 1].transform.position.x >= (Screen.width / 2 )) {
						moving = -1;
					}
					if (Input.GetKey (KeyCode.RightArrow) && subraces[0].transform.position.x <= (Screen.width / 2 )) {
						moving = 1;
					}
					if (moving != 0) {
					
						for (int i=0; i<num_of_subraces; i++) {
							var x_pos = (subraces [i].transform.position.x + (moving * 500) * transitionSpeed * Time.deltaTime);
							subraces [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
						}
						moving = 0;
					}
		}

	void GetSubraces()
	{
		List<string> subraceNameList = new List<string> ();
		int i = 0;
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		string subrace_name_tag = Character_Info.characterRace + "name";
		string subrace_descr_tag = Character_Info.characterRace + "descr";
		subraceNameList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/subracesOverview.xml", subrace_name_tag);
		foreach( var item in subraceNameList)
		{
			subraceNames[i].GetComponent<Text>().text = item;
			i++;
		}
		num_of_subraces = i;
		//If there are no subraces then skip to class selection
		if (i == 0) {
			Character_Info.characterSubrace = "N / A";
			Application.LoadLevel ("Class Selection");
		}

		subraceDescrList = subraceNameList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/subracesOverview.xml", subrace_descr_tag);
	}

	public void SelectSubrace(int position){
		Character_Info.characterSubrace = subraceNames [position].GetComponent<Text> ().text;
		Application.LoadLevel ("Class Selection");
	}

	public void FillSubraceDescription(int position)
	{
		StartCoroutine (DescrFadeIn ());
		subraceDescription.GetComponent<Text>().text = subraceDescrList[position];
	}

	public void ClearSubraceDescription ()
	{
		StartCoroutine(DescrFadeOut());
		subraceDescription.GetComponent<Text> ().text = "";
	}

	IEnumerator DescrFadeIn()
	{
		while (subraceDescrCanvasGroup.alpha < 1) {
			subraceDescrCanvasGroup.alpha += Time.deltaTime * transitionSpeed * 2;
			yield return null;
		}
		subraceDescrCanvasGroup.alpha = 1;
		yield return null;
	}

	IEnumerator DescrFadeOut()
	{
		while (subraceDescrCanvasGroup.alpha > 0) {
			subraceDescrCanvasGroup.alpha -= Time.deltaTime * transitionSpeed * 2;
			yield return null;
		}
		subraceDescrCanvasGroup.alpha = 0;
		yield return null;
	}

}