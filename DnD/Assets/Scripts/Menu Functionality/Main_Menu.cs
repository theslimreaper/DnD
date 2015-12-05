using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class Main_Menu : MonoBehaviour {
    public Message_Handler MessageBoxOK;
    public Message_Handler MessageBoxYN;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Create new character
	public void createNewCharacter()
    {
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        List<string> tempList = new List<string>();
        tempList = Load.LoadCharacterIDs();
        Character_Info.id = Character_Info.maxid;
		Application.LoadLevel ("Character Creation");
	}

	//Load character from file
	public void loadExistingCharacter()
	{
		Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader> ();
		Application.LoadLevel ("Screen Hub");
	}

	//Leave the application
	void exitGame()
	{
		Application.Quit ();
	}

    //Prompt user about leaving the application
    public void exitGamePrompt()
    {
        MessageBoxYN.ShowBox("Are you sure you want to exit the application?");
        MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => exitGame());
    }

	//Shows about us screen
	public void aboutUs()
	{
		Application.LoadLevel ("Credits");
	}
}