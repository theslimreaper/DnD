using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Side_Menu : MonoBehaviour {
	public static bool is_paused = false;
	public CanvasGroup CanvasGroup;
	public GameObject PauseMenu;
    public GameObject SideMenuMain;
    public float transition_speed;

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