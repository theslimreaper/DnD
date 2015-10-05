using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character_Info_Edit : MonoBehaviour {

	public GameObject editscreen;
	public GameObject displayscreen;

	void Start(){
		DisplayMode ();
	}

	public void EditMode(){
		editscreen.SetActive (true);
		displayscreen.SetActive (false);
	}

	public void DisplayMode(){
		editscreen.SetActive (false);
		displayscreen.SetActive (true);
	}
}
