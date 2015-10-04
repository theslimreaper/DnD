using UnityEngine;
using System.Collections;

public class MainMenuFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createNewCharacter()
	{
		Application.LoadLevel ("Race Selection");
		Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver> ();
		Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader> ();
		Save.SaveData ("test");
		print ("Save successful!");
		Load.LoadData ("test.xml");
	}
	public void loadExistingCharacter()
	{
		print ("feature not available yet");
	}
	public void exitGame()
	{
		Application.Quit ();
	}
	public void aboutUs()
	{
		Application.LoadLevel ("Credits");
	}

}