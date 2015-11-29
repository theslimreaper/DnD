using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Save_Combat_Info_Edit : MonoBehaviour {
	
	public GameObject editAC;
	public GameObject displayAC;
	public GameObject editBAB;
	public GameObject displayBAB;
	public GameObject editWill;
	public GameObject displayWill;
	public GameObject editCMB;
	public GameObject displayCMB;
	public GameObject editInitiative;
	public GameObject displayInitiative;
	public GameObject editReflex;
	public GameObject displayReflex;
	public GameObject editFortitude;
	public GameObject displayFortitude;
	public GameObject editCMD;
	public GameObject displayCMD;
	
	// Use this for initialization
	void Start () {
        editAC.GetComponent<InputField>().text = Character_Info.combatAC;
        editBAB.GetComponent<InputField>().text = Character_Info.combatBAB;
        editWill.GetComponent<InputField>().text = Character_Info.combatWill;
        editCMB.GetComponent<InputField>().text = Character_Info.combatCMB;
        editInitiative.GetComponent<InputField>().text = Character_Info.combatInitiative;
        editReflex.GetComponent<InputField>().text = Character_Info.combatReflex;
        editFortitude.GetComponent<InputField>().text = Character_Info.combatFortitude;
        editCMD.GetComponent<InputField>().text = Character_Info.combatCMD;
        DisplayMode();
    }
	
	public void DisplayMode(){
		Character_Info.combatAC = displayAC.GetComponent<InputField>().text = editAC.GetComponent<InputField>().text;
        Character_Info.combatBAB = displayBAB.GetComponent<InputField>().text = editBAB.GetComponent<InputField>().text;
        Character_Info.combatWill = displayWill.GetComponent<InputField>().text = editWill.GetComponent<InputField>().text;
        Character_Info.combatCMB = displayCMB.GetComponent<InputField>().text = editCMB.GetComponent<InputField>().text;
        Character_Info.combatInitiative = displayInitiative.GetComponent<InputField>().text = editInitiative.GetComponent<InputField>().text;
        Character_Info.combatReflex = displayReflex.GetComponent<InputField>().text = editReflex.GetComponent<InputField>().text;
        Character_Info.combatFortitude = displayFortitude.GetComponent<InputField>().text = editFortitude.GetComponent<InputField>().text;
        Character_Info.combatCMD = displayCMD.GetComponent<InputField>().text = editCMD.GetComponent<InputField>().text;
	}

    public void EditMode()
    {
        editAC.GetComponent<InputField>().text = displayAC.GetComponent<InputField>().text;
        editBAB.GetComponent<InputField>().text = displayBAB.GetComponent<InputField>().text;
        editWill.GetComponent<InputField>().text = displayWill.GetComponent<InputField>().text;
        editCMB.GetComponent<InputField>().text = displayCMB.GetComponent<InputField>().text;
        editInitiative.GetComponent<InputField>().text = displayInitiative.GetComponent<InputField>().text;
        editReflex.GetComponent<InputField>().text = displayReflex.GetComponent<InputField>().text;
        editFortitude.GetComponent<InputField>().text = displayFortitude.GetComponent<InputField>().text;
        editCMD.GetComponent<InputField>().text = displayCMD.GetComponent<InputField>().text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
