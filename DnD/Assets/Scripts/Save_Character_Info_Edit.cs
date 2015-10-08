using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Save_Character_Info_Edit : MonoBehaviour {

	public GameObject editName;
	public GameObject displayName;
	public GameObject editClass;
	public GameObject displayClass;
	public GameObject editRace;
	public GameObject displayRace;
	public GameObject editAlignment;
	public GameObject displayAlignment;
	public GameObject editAge;
	public GameObject displayAge;
	public GameObject editGender;
	public GameObject displayGender;
	public GameObject editLevel;
	public GameObject displayLevel;
	public GameObject editHP;
	public GameObject displayHP;
	public GameObject editHeight;
	public GameObject displayHeight;
	public GameObject editWeight;
	public GameObject displayWeight;
	public GameObject editCarry;
	public GameObject displayCarry;
	public GameObject editSpeed;
	public GameObject displaySpeed;
	public GameObject editLanguage;
	public GameObject displayLanguage;

	// Use this for initialization
	void Start () {
	
	}

	public void Edit(){
		displayName.GetComponent<Text> = editName.GetComponent<InputField>;
		displayClass.GetComponent<Text> = editClass.GetComponent<InputField>;
		displayRace.GetComponent<Text> = editRace.GetComponent<InputField>;
		displayAlignment.GetComponent<Text> = editAlignment.GetComponent<InputField>;
		displayAge.GetComponent<Text> = editAge.GetComponent<InputField>;
		displayGender.GetComponent<Text> = editGender.GetComponent<InputField>;
		displayLevel.GetComponent<Text> = editLevel.GetComponent<InputField>;
		displayHP.GetComponent<Text> = editHP.GetComponent<InputField>;
		displayHeight.GetComponent<Text> = editHeight.GetComponent<InputField>;
		displayWeight.GetComponent<Text> = editWeight.GetComponent<InputField>;
		displayCarry.GetComponent<Text> = editCarry.GetComponent<InputField>;
		displaySpeed.GetComponent<Text> = editSpeed.GetComponent<InputField>;
		displayLanguage.GetComponent<Text> = editLanguage.GetComponent<InputField>;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
