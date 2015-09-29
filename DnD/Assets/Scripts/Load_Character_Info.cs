using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load_Character_Info : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Character_Class_Text").GetComponent<Text> ().text = Character_Info.characterClass;
		print (GameObject.FindGameObjectWithTag ("Character_Class_Text").GetComponent<Text> ().text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
