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
    public GameObject displayAvatar;
    public GameObject editAvatar;
    public GameObject editCurrHP;
    public GameObject displayCurrHP;

	// Use this for initialization
	void Start () {
	}

	public void DisplayMode(){
		displayName.GetComponent<InputField>().text = editName.GetComponent<InputField>().text;
		displayClass.GetComponent<InputField>().text = editClass.GetComponent<InputField>().text;
		displayRace.GetComponent<InputField>().text = editRace.GetComponent<InputField>().text;
		displaySubRace.GetComponent<InputField>().text = editSubRace.GetComponent<InputField>().text;
		displayAlignment.GetComponent<InputField>().text = editAlignment.GetComponent<InputField>().text;
		displayAge.GetComponent<InputField>().text = editAge.GetComponent<InputField>().text;
		displayGender.GetComponent<InputField>().text = editGender.GetComponent<InputField>().text;
		displayLevel.GetComponent<InputField>().text = editLevel.GetComponent<InputField>().text;
		displayHP.GetComponent<InputField>().text = editHP.GetComponent<InputField>().text;
        displayCurrHP.GetComponent<InputField>().text = editCurrHP.GetComponent<InputField>().text;
        displayHeight.GetComponent<InputField>().text = editHeight.GetComponent<InputField>().text;
		displayWeight.GetComponent<InputField>().text = editWeight.GetComponent<InputField>().text;
		displayCarry.GetComponent<InputField>().text = editCarry.GetComponent<InputField>().text;
		displaySpeed.GetComponent<InputField>().text = editSpeed.GetComponent<InputField>().text;
		displayLanguage.GetComponent<InputField>().text = editLanguage.GetComponent<InputField>().text;
        displayAvatar.GetComponent<Image>().sprite = editAvatar.GetComponent<Image>().sprite;

	}

    public void EditMode()
    {
        editName.GetComponent<InputField>().text = displayName.GetComponent<InputField>().text;
        editClass.GetComponent<InputField>().text = displayClass.GetComponent<InputField>().text;
        editRace.GetComponent<InputField>().text = displayRace.GetComponent<InputField>().text;
        editSubRace.GetComponent<InputField>().text = displaySubRace.GetComponent<InputField>().text;
        editAlignment.GetComponent<InputField>().text = displayAlignment.GetComponent<InputField>().text;
        editAge.GetComponent<InputField>().text = displayAge.GetComponent<InputField>().text;
        editGender.GetComponent<InputField>().text = displayGender.GetComponent<InputField>().text;
        editLevel.GetComponent<InputField>().text = displayLevel.GetComponent<InputField>().text;
        editHP.GetComponent<InputField>().text = displayHP.GetComponent<InputField>().text;
        editCurrHP.GetComponent<InputField>().text = displayCurrHP.GetComponent<InputField>().text;
        editHeight.GetComponent<InputField>().text = displayHeight.GetComponent<InputField>().text;
        editWeight.GetComponent<InputField>().text = displayWeight.GetComponent<InputField>().text;
        editCarry.GetComponent<InputField>().text = displayCarry.GetComponent<InputField>().text;
        editSpeed.GetComponent<InputField>().text = displaySpeed.GetComponent<InputField>().text;
        editLanguage.GetComponent<InputField>().text = displayLanguage.GetComponent<InputField>().text;
        editAvatar.GetComponent<Image>().sprite = displayAvatar.GetComponent<Image>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
