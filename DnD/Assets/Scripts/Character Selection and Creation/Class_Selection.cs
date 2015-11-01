using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Class_Selection : MonoBehaviour {
	
	public GameObject[] classes;
	public GameObject[] classNames;
	public int transitionSpeed;
	public GameObject classDescription;
	public CanvasGroup classDescrCanvasGroup;
	List<string> classDescrList = new List<string>();
	int moving;
	float screenRatioW = (float)Screen.width / (float)1920;

	// Start and Update functions

	void Start () {
		FormatStartLayout ();
		GetClasses ();
	}

	void LateUpdate()
	{
		UpdateLayout ();
	}

	//Additional Functions

	//Set initial layout of content
	void FormatStartLayout () 
		{
			for (int i=0; i<classes.Length; i++) {
				var x_pos = ((Screen.width / 2) + (500 * i * screenRatioW));
				classes [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
			}
		}
	
	//Update content position based on arrow key presses
	void UpdateLayout()
	{
		if (Input.GetKey (KeyCode.LeftArrow) && classes[0].transform.position.x <= (Screen.width / 2 )) {
						moving = 1;
					}
		if (Input.GetKey (KeyCode.RightArrow) && classes[classes.Length - 1].transform.position.x >= (Screen.width / 2 )) {
						moving = -1;
					}
					if (moving != 0) {
					
						for (int i=0; i<classes.Length; i++) {
							var x_pos = (classes [i].transform.position.x + (moving * 500 * screenRatioW) * transitionSpeed * Time.deltaTime);
							classes [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
						}
						moving = 0;
					}
		}

	//Confirm base character information and enter Screen Hub scene
	public void ConfirmCharacter()
	{
		Application.LoadLevel ("Screen Hub");
	}

	void GetClasses()
	{
		List<string> classNameList = new List<string> ();
		int i = 0;
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
        if(Settings_Screen.is_online == true)
        {
		classNameList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classesOverview.xml", "classname");
        }
        else
        {
            classNameList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/classesOverview.xml", "classname");
        }
		foreach( var item in classNameList)
		{
			classNames[i].GetComponent<Text>().text = item;
			i++;
		}

        if(Settings_Screen.is_online == true)
        {
		classDescrList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classesOverview.xml", "description");
        }
        else
        {
            classDescrList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/classesOverview.xml", "description");
        }
	}

	//Choose character class and confirm selections
	public void SelectClass(int position){
		Character_Info.characterClass = classNames [position].GetComponent<Text> ().text;
		ConfirmCharacter ();
	}

	//Show the description of the highlighted class
	public void FillClassDescription(int position)
	{
		StartCoroutine (DescrFadeIn ());
		classDescription.GetComponent<Text>().text = classDescrList[position];
	}

	//Clear the class description
	public void ClearClassDescription ()
	{
		StartCoroutine(DescrFadeOut());
		classDescription.GetComponent<Text> ().text = "";
	}

	//Bring the class description into view
	IEnumerator DescrFadeIn()
	{
		while (classDescrCanvasGroup.alpha < 1) {
			classDescrCanvasGroup.alpha += Time.deltaTime * transitionSpeed * 2;
			yield return null;
		}
		classDescrCanvasGroup.alpha = 1;
		yield return null;
	}

	//Take the class description out of view
	IEnumerator DescrFadeOut()
	{
		while (classDescrCanvasGroup.alpha > 0) {
			classDescrCanvasGroup.alpha -= Time.deltaTime * transitionSpeed * 2;
			yield return null;
		}
		classDescrCanvasGroup.alpha = 0;
		yield return null;
	}

}