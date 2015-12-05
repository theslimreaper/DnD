using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class Side_Menu : MonoBehaviour {
	public static bool is_paused = false;
	public CanvasGroup CanvasGroup;
	public GameObject PauseMenu;
    public GameObject SideMenuMain;
    public float transition_speed;
	public Message_Handler MessageBoxOK;
	public Message_Handler MessageBoxYN;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "Screen Hub") {
			HidePauseMenu ();
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
        {
			AlternatePauseMenu ();
		}
	}

	//Create new character
	void createNewCharacter()
	{
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        List<string> tempList = new List<string>();
        tempList = Load.LoadCharacterIDs();
		HidePauseMenu ();
        Character_Info.id = Character_Info.maxid;
		Application.LoadLevel ("Character Creation");
	}

	//Prompt user that unsaved changes will be lost when creating a new character
	public void createCharacterPrompt()
	{
		MessageBoxYN.ShowBox ("WARNING: Creating a new character will result in the loss of unsaved changes for the current character! Continue?");
		MessageBoxYN.gameObject.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.GetComponent<Button>().onClick.AddListener ( () => createNewCharacter ());
	}

	//Load character from file
	public void loadExistingCharacter()
	{
		HidePauseMenu ();
		Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader> ();
		Application.LoadLevel ("Screen Hub");
	}

    //Prompt user to confirm to delete current character
    public void deleteCharacterPrompt()
    {
        MessageBoxYN.ShowBox("WARNING: Are you sure you want to delete this character? If you do, there will be no way to recover its data!");
        MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => confirmDeleteCharacter());
    }

    //Delete character after user confirmation and prompt that the user will return to the main menu
    public void confirmDeleteCharacter()
    {
        Data_Deleter Delete = ScriptableObject.CreateInstance<Data_Deleter>();

        Delete.DeleteFile();
        MessageBoxOK.ShowBox("The current character has been successfully deleted! Please click OK to return to the main menu.");
        MessageBoxOK.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => Application.LoadLevel("Start Screen"));

    }

	//Leave the application
	void exitGame()
	{
		Application.Quit ();
	}

	//Prompt user that unsaved changes will be lost when exiting the application
	public void exitGamePrompt()
	{
		MessageBoxYN.ShowBox ("WARNING: Exiting the application will result in the loss of unsaved changes for the current character! Continue?");
		MessageBoxYN.gameObject.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.GetComponent<Button>().onClick.AddListener ( () => exitGame ());
	}

	//Shows about us (credits) screen
	public void aboutUs()
	{
		HidePauseMenu ();
		Application.LoadLevel ("Credits");
	}

	//Deselect selected game objects such as input fields
	public void DeselectObjects(){
	}

	//Show all pause menu game objects
	void ShowPauseMenu(){
		DeselectObjects ();
		is_paused = true;
		//PauseMenu.SetActive(true);
        StartCoroutine(ScreenIn());
	}

	//Hide all pause menu game objects
	void HidePauseMenu(){
		is_paused = false;
		//PauseMenu.SetActive (false);
        StartCoroutine(ScreenOut());
    }

	//Toggle show/hide pause menu
	public void AlternatePauseMenu(){
		switch( is_paused )
		{
		case false:
			ShowPauseMenu ();
			break;
		case true:
			HidePauseMenu ();
			break;
		}
	}

    //Slide side menu out of view
    IEnumerator ScreenOut()
    {
        while (SideMenuMain.transform.position.x >= -2000)
        {
            Vector3 new_position = new Vector3(100*transition_speed, SideMenuMain.transform.position.y, SideMenuMain.transform.position.z);
            SideMenuMain.transform.position -= new_position;
            yield return null;
        }
    }

    //Slide side menu into view
    IEnumerator ScreenIn()
    {
        while (SideMenuMain.transform.position.x < 0)
        {
            Vector3 new_position = new Vector3(100*transition_speed, SideMenuMain.transform.position.y, SideMenuMain.transform.position.z);
            SideMenuMain.transform.position += new_position;
            yield return null;
        }
    }

}