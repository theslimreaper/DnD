using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Main_Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Create new character
	public void createNewCharacter()
	{
		Application.LoadLevel ("Race Selection");
	}

	//Load character from file
	public void loadExistingCharacter()
	{
		Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader> ();
		Load.LoadData ("test.xml");
		Application.LoadLevel ("Screen Hub");
	}

	//Leave the application
	public void exitGame()
	{
		Application.Quit ();
	}

	//Shows about us screen
	public void aboutUs()
	{
		Application.LoadLevel ("Credits");
	}
}