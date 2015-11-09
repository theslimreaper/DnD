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
    public Primary_Note_Functions Note_Functions;
    public Note_Editor NoteEditor;
	
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
		foreach (var item in Note_List_Info.noteTitles) {
			num_of_notes++;
		}
        ScrollBar = ScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
		ScrollBar.value = 0;
        if (ParentRectDefault != null)
        {
            ParentRect.sizeDelta = new Vector2(ParentRectDefault.rect.width, 0);
            if (num_of_notes > 0)
            {
                ScrollView.transform.position = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y, 250);

                for (int i = 0; i < num_of_notes; i++)
                {
                    GameObject noteButton = (GameObject)Instantiate(Select_Note_Button);
                    GameObject titleText = noteButton.gameObject.transform.GetChild(0).gameObject;
                    GameObject dateText = noteButton.gameObject.transform.GetChild(1).gameObject;
                    noteButton.transform.SetParent(ParentButton, false);
                    noteButton.transform.localScale = new Vector3(0.18f, 0.1f, 0);
                    titleText.transform.localScale = new Vector3(1, 1, 1);
                    titleText.GetComponent<Text>().text = PeekAtTitle(i);
                    dateText.GetComponent<Text>().text = PeekAtDate(i);
                    if (i == 0)
                    {
                        noteButton.transform.position = new Vector3(ParentText.transform.position.x, ParentText.transform.position.y, 250);
                    }
                    else
                    {
                        noteButton.transform.position = new Vector3(ParentText.transform.position.x, ParentText.transform.position.y - (40 * i * screenRatio), 250);
                    }

                    dynamicObjects.Add(noteButton);
                    Button tempButton = noteButton.gameObject.GetComponent<Button>();
                    int position = i;

                    tempButton.onClick.AddListener(() => SelectNote(position));
                }
            }

            if (dynamicObjects.Count > 0)
            {
                ParentRect.sizeDelta = new Vector2(ParentRectDefault.rect.width, screenRatio * (ParentRectHeight - (dynamicObjects[num_of_notes - 1].transform.position.y - (dynamicObjects[num_of_notes - 1].GetComponent<RectTransform>().rect.height))));
                ScrollBar.value = 1;
            }
        }
	}
	

	void SelectNote(int position)
	{
        NoteEditor.title.GetComponent<InputField>().text = Note_List_Info.noteTitles[position];
        NoteEditor.date.GetComponent<InputField>().text = Note_List_Info.noteDates[position];
        NoteEditor.subject.GetComponent<InputField>().text = Note_List_Info.noteSubjects[position];
        Note_List_Info.note = position;
        Note_Functions.SetEditView();
	}

	string PeekAtTitle(int i){
		string text = "Title: " + Note_List_Info.noteTitles[i];
		return text;
	}

    string PeekAtDate(int i)
    {
        string text = "Date: " + Note_List_Info.noteDates[i];
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
