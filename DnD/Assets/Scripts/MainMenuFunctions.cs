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
					DeselectObjects ();
					is_paused = true;
					CanvasGroup.alpha = 1;
					CanvasGroup.interactable = true;
					PauseMenu.SetActive(true);
					break;
				case true:
					is_paused = false;
				CanvasGroup.alpha = 0;
				CanvasGroup.interactable = false;
				PauseMenu.SetActive (false);
				break;
			}
		}
	}

	public void createNewCharacter()
	{
		Application.LoadLevel ("Race Selection");
	}
	public void loadExistingCharacter()
	{
		Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader> ();
		Load.LoadData ("test.xml");
		Application.LoadLevel ("Base");
	}
	public void exitGame()
	{
		Application.Quit ();
	}
	public void aboutUs()
	{
		Application.LoadLevel ("Credits");
	}
	public void SaveCharacter(){
		Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver> ();
		Save.SaveData (Character_Info.characterName);
		print ("Save successful!");
	}
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

}