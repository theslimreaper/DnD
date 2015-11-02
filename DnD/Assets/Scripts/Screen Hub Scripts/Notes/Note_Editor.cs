using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class Note_Editor : MonoBehaviour {
	public GameObject title;
	public GameObject date;
	public GameObject subject;
	public Primary_Note_Functions Note_Functions;
	// Use this for initialization
	void Start () {
		ClearFields ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ClearFields()
	{
		title.GetComponent<InputField> ().text = "";
		date.GetComponent<InputField> ().text = "";
		subject.GetComponent<InputField> ().text = "";
	}

	public void SaveNote()
	{
		Primary_Note_Functions.noteTitles.Add (title.GetComponent<InputField> ().text);
		Primary_Note_Functions.noteDates.Add (date.GetComponent<InputField> ().text);
		Primary_Note_Functions.noteSubjects.Add (subject.GetComponent<InputField> ().text);
		ClearFields ();
		Note_Functions.SetListView ();
	}

	public void CancelNote()
	{
		ClearFields ();
		Note_Functions.SetListView ();
	}
}
