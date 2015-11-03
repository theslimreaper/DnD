using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class Primary_Note_Functions : MonoBehaviour {
	GameObject[] noteList;
	public GameObject listView;
	public GameObject editView;
	public Note_List NoteList;
    public Note_Editor NoteEditor;
    public GameObject saveButton;
    public GameObject deleteButton;
	// Use this for initialization
	void Start () {
		SetListView ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetListView(){
		listView.GetComponent<CanvasGroup>().alpha = 1;
		listView.GetComponent<CanvasGroup>().interactable = true;
		listView.SetActive (true);
		editView.GetComponent<CanvasGroup>().alpha = 0;
		editView.GetComponent<CanvasGroup>().interactable = false;
		editView.SetActive (false);
		NoteList.SetLayout ();
        deleteButton.GetComponent<Button>().onClick.RemoveAllListeners();
        saveButton.GetComponent<Button>().onClick.RemoveAllListeners();
	}

	public void SetEditView(){
		listView.GetComponent<CanvasGroup>().alpha = 0;
		listView.GetComponent<CanvasGroup>().interactable = false;
		listView.SetActive (false);
		editView.GetComponent<CanvasGroup>().alpha = 1;
		editView.GetComponent<CanvasGroup>().interactable = true;
		editView.SetActive (true);
        int i = Note_List_Info.note;
        if (Note_List_Info.note == -1)
        {
            deleteButton.GetComponent<CanvasGroup>().alpha = 0;
            deleteButton.GetComponent<CanvasGroup>().interactable = false;
            deleteButton.SetActive(false);
        }
        else
        {
            deleteButton.GetComponent<CanvasGroup>().alpha = 1;
            deleteButton.GetComponent<CanvasGroup>().interactable = true;
            deleteButton.SetActive(true);
            deleteButton.GetComponent<Button>().onClick.AddListener(() => NoteEditor.DeleteNote(i));
        }
       saveButton.GetComponent<Button>().onClick.AddListener(() => NoteEditor.SaveNote(i));
	}
}
