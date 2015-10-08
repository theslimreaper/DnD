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
	public GameObject editSubRace;
	public GameObject displaySubRace;

	// Use this for initialization
	void Start () {
	
	}

	public void Edit(){
		displayName.GetComponent<Text>().text = editName.GetComponent<InputField>().text;
		displayClass.GetComponent<Text>().text = editClass.GetComponent<InputField>().text;
		displayRace.GetComponent<Text>().text = editRace.GetComponent<InputField>().text;
		displaySubRace.GetComponent<Text>().text = editSubRace.GetComponent<InputField>().text;
		displayAlignment.GetComponent<Text>().text = editAlignment.GetComponent<InputField>().text;
		displayAge.GetComponent<Text>().text = editAge.GetComponent<InputField>().text;
		displayGender.GetComponent<Text>().text = editGender.GetComponent<InputField>().text;
		displayLevel.GetComponent<Text>().text = editLevel.GetComponent<InputField>().text;
		displayHP.GetComponent<Text>().text = editHP.GetComponent<InputField>().text;
		displayHeight.GetComponent<Text>().text = editHeight.GetComponent<InputField>().text;
		displayWeight.GetComponent<Text>().text = editWeight.GetComponent<InputField>().text;
		displayCarry.GetComponent<Text>().text = editCarry.GetComponent<InputField>().text;
		displaySpeed.GetComponent<Text>().text = editSpeed.GetComponent<InputField>().text;
		displayLanguage.GetComponent<Text>().text = editLanguage.GetComponent<InputField>().text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
