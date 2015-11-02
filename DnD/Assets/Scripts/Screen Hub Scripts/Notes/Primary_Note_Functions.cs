using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class Primary_Note_Functions : MonoBehaviour {
	GameObject[] noteList;
	public static List<string> noteTitles = new List<string>();
	public static List<string> noteDates = new List<string>();
	public static List<string> noteSubjects = new List<string>();
	public GameObject listView;
	public GameObject editView;
	public Note_List NoteList;
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
	}

	public void SetEditView(){
		listView.GetComponent<CanvasGroup>().alpha = 0;
		listView.GetComponent<CanvasGroup>().interactable = false;
		listView.SetActive (false);
		editView.GetComponent<CanvasGroup>().alpha = 1;
		editView.GetComponent<CanvasGroup>().interactable = true;
		editView.SetActive (true);
	}
}
