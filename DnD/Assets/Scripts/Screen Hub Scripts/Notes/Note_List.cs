using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;

public class Note_List : MonoBehaviour {
	public GameObject Select_Note_Button;
	public GameObject Select_Note_Text;
	public GameObject ScrollView;
	public static List<GameObject> dynamicObjects = new List<GameObject>();
	public RectTransform ParentButton;
	static RectTransform ParentButtonDefault;
	public RectTransform ParentText;
	static RectTransform ParentRectDefault;
	static float ParentRectHeight;
	RectTransform ParentRect;
	float screenRatio = (float)Screen.height / (float)1080;
	Scrollbar ScrollBar;
	
	// Use this for initialization
	void Start () {
		ParentButtonDefault = ParentButton;
		ParentRectDefault = ParentButtonDefault.GetComponent<RectTransform>();
		ParentRectHeight = ParentRectDefault.rect.height;
		ParentRect = ParentRectDefault;
		ScrollBar = ScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
	}

	public void SetLayout()
	{
		int num_of_notes = 0;
		DeleteList ();
		foreach (var item in Primary_Note_Functions.noteTitles) {
			num_of_notes++;
		}
		ScrollBar.value = 0;
		ParentRect.sizeDelta = new Vector2 (ParentRectDefault.rect.width, 0);
		if (num_of_notes > 0) {
			ScrollView.transform.position = new Vector3 (ScrollView.transform.position.x, ScrollView.transform.position.y, 300);
				
			for (int i = 0; i < num_of_notes; i++) {
				GameObject noteButton = (GameObject)Instantiate (Select_Note_Button);
				GameObject noteText = noteButton.gameObject.transform.GetChild (0).gameObject;
				noteButton.transform.SetParent (ParentButton, false);
				noteButton.transform.localScale = new Vector3 (0.1798507f, 0.1948383f, 0.02338059f);
				noteText.transform.localScale = new Vector3 (1.798507f * 0.5f, 1.948383f * 0.5f, 2.338059f * 0.5f);
				noteText.GetComponent<Text> ().text = PeekAtNote (i);
				if (i == 0) {
					noteButton.transform.position = new Vector3 (ParentText.transform.position.x, ParentText.transform.position.y, 0);
				} else {
					noteButton.transform.position = new Vector3 (ParentText.transform.position.x, ParentText.transform.position.y - (150 * i * screenRatio), 0);
				}
					
				dynamicObjects.Add (noteButton);
				Button tempButton = noteButton.gameObject.GetComponent<Button> ();
				int position = i;
					
				tempButton.onClick.AddListener (() => SelectNote (position));
			}
		}
		
		if (dynamicObjects.Count > 0) {
			ParentRect.sizeDelta = new Vector2 (ParentRectDefault.rect.width, (ParentRectHeight - (dynamicObjects [num_of_notes - 1].transform.position.y - (1.7f * dynamicObjects [num_of_notes - 1].GetComponent<RectTransform> ().rect.height))));
			ScrollBar.value = 1;
		}
	}
	

	void SelectNote(int position)
	{
	}

	string PeekAtNote(int i){
		string text = "Title: " + Primary_Note_Functions.noteTitles[i] + " Date: " + Primary_Note_Functions.noteDates[i];
		return text;
	}
	
	//Destroy all dynamically created objects for the list
	public void DeleteList()
	{
		foreach (var item in dynamicObjects)
		{
			Destroy(item);
		}
		
		dynamicObjects.Clear();
		
		ScrollView.transform.position = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y, -10000);
	}
	
}
