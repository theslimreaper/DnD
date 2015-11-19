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
		editAC.GetComponent<InputField>().text = displayAC.GetComponent<Text>().text;
		editBAB.GetComponent<InputField>().text = displayBAB.GetComponent<Text>().text;
		editWill.GetComponent<InputField>().text = displayWill.GetComponent<Text>().text;
		editCMB.GetComponent<InputField>().text = displayCMB.GetComponent<Text>().text;
		editInitiative.GetComponent<InputField>().text = displayInitiative.GetComponent<Text>().text;
		editReflex.GetComponent<InputField>().text = displayReflex.GetComponent<Text>().text;
		editFortitude.GetComponent<InputField>().text = displayFortitude.GetComponent<Text>().text;
		editCMD.GetComponent<InputField>().text = displayCMD.GetComponent<Text>().text;
	}
	
	public void Edit(){
		displayAC.GetComponent<Text>().text = editAC.GetComponent<InputField>().text;
		displayBAB.GetComponent<Text>().text = editBAB.GetComponent<InputField>().text;
		displayWill.GetComponent<Text>().text = editWill.GetComponent<InputField>().text;
		displayCMB.GetComponent<Text>().text = editCMB.GetComponent<InputField>().text;
		displayInitiative.GetComponent<Text>().text = editInitiative.GetComponent<InputField>().text;
		displayReflex.GetComponent<Text>().text = editReflex.GetComponent<InputField>().text;
		displayFortitude.GetComponent<Text>().text = editFortitude.GetComponent<InputField>().text;
		displayCMD.GetComponent<Text>().text = editCMD.GetComponent<InputField>().text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
