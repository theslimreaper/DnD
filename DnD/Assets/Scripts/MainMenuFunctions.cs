using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class MainMenuFunctions : MonoBehaviour {
	public static bool is_paused = false;
	public CanvasGroup CanvasGroup;
	public GameObject PauseMenu;

	// Use this for initialization
	void Start () {
		Character_Info.characterName = "test";
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "Base" && Input.GetKeyDown( KeyCode.F1 )) {
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
	}

	//Create new character
	public void createNewCharacter()
	{
		HidePauseMenu ();
		Application.LoadLevel ("Race Selection");
	}

	//Load character from file
	public void loadExistingCharacter()
	{
		HidePauseMenu ();
		Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader> ();
		Load.LoadData ("test.xml");
		Application.LoadLevel ("Base");
	}

	//Leave the application
	public void exitGame()
	{
		Application.Quit ();
	}

	//Shows about us screen
	public void aboutUs()
	{
		HidePauseMenu ();
		Application.LoadLevel ("Credits");
	}

	//Deselect selected game objects such as input fields
	public void DeselectObjects(){
			GameObject[] objs = Selection.gameObjects;
			List<GameObject> parents = new List<GameObject>();
			foreach (GameObject obj in objs) {
				if (obj.transform.parent != null) {
					parents.Add(obj.transform.parent.gameObject);
				}
			}
			Selection.objects = parents.ToArray();
	}

	//Show all pause menu game objects
	void ShowPauseMenu(){
		DeselectObjects ();
		is_paused = true;
		CanvasGroup.alpha = 1;
		CanvasGroup.interactable = true;
		PauseMenu.SetActive(true);
	}

	//Hide all pause menu game objects
	void HidePauseMenu(){
		is_paused = false;
		CanvasGroup.alpha = 0;
		CanvasGroup.interactable = false;
		PauseMenu.SetActive (false);
	}

}