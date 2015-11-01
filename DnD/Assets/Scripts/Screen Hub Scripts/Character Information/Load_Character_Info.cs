using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load_Character_Info : MonoBehaviour {
    public GameObject Class;
	public GameObject Race;
	// Use this for initialization
	void Start () {

        Class.GetComponent<InputField>().text = Character_Info.characterClass;
		Race.GetComponent<InputField>().text = Character_Info.characterRace;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
