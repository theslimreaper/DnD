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
    public Message_Handler MessageBoxYN;
    public Message_Handler MessageBoxOK;
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
        Note_List_Info.note = -1;
	}

	public void SaveNote(int position)
	{
        if (position == -1)
        {
            Note_List_Info.noteTitles.Add(title.GetComponent<InputField>().text);
            Note_List_Info.noteDates.Add(date.GetComponent<InputField>().text);
            Note_List_Info.noteSubjects.Add(subject.GetComponent<InputField>().text);
        }
        else
        {
            Note_List_Info.noteTitles[position] = title.GetComponent<InputField>().text;
            Note_List_Info.noteDates[position] = date.GetComponent<InputField>().text;
            Note_List_Info.noteSubjects[position] = subject.GetComponent<InputField>().text;
        }
        MessageBoxOK.ShowBox("Save successful!");
		ClearFields ();
		Note_Functions.SetListView ();
	}

	public void CancelNote()
	{
		ClearFields ();
		Note_Functions.SetListView ();
	}

    public void DeleteNote(int position)
    {
        MessageBoxYN.ShowBox("Are you sure you want to delete this note?");
        MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => ConfirmDelete(position));
    }

    void ConfirmDelete(int position)
    {
        Note_List_Info.noteTitles.RemoveAt(position);
        Note_List_Info.noteDates.RemoveAt(position);
        Note_List_Info.noteSubjects.RemoveAt(position);
        ClearFields();
        Note_Functions.SetListView();
    }
}