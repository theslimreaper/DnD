using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Character_Creation : MonoBehaviour {
	
	public GameObject[] classes;
	public GameObject[] classNames;
	public int transitionSpeed;
	int moving;


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
				var x_pos = ((Screen.width / 2) + (500 * i));
				classes [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
			}
		}
	
	//Update content position based on arrow key presses
	void UpdateLayout()
	{
					if (Input.GetKey (KeyCode.LeftArrow) && classes[classes.Length - 1].transform.position.x >= (Screen.width / 2 )) {
						moving = -1;
					}
					if (Input.GetKey (KeyCode.RightArrow) && classes[0].transform.position.x <= (Screen.width / 2 )) {
						moving = 1;
					}
					if (moving != 0) {
					
						for (int i=0; i<classes.Length; i++) {
							var x_pos = (classes [i].transform.position.x + (moving * 500) * transitionSpeed * Time.deltaTime);
							classes [i].transform.position = new Vector3 (x_pos, transform.position.y, transform.position.z);
						}
						moving = 0;
					}
		}

	public void ConfirmCharacter()
	{
		Application.LoadLevel ("Base");
	}

	void GetClasses()
	{
		List<string> classNameList = new List<string> ();
		int i = 0;
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		var name = "";
		classNameList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classes.xml", "classname");
		foreach( var item in classNameList)
		{
			classNames[i].GetComponent<Text>().text = item;
			i++;
		}
	}
}