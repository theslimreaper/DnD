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
	public GameObject editWName;
	public GameObject displayWName;
	public GameObject editWDamage;
	public GameObject displayWDamage;
	public GameObject editWCrit;
	public GameObject displayWCrit;
	public GameObject editWSpecial;
	public GameObject displayWSpecial;
	public GameObject editWWeight;
	public GameObject displayWWeight;
	public GameObject editWCost;
	public GameObject displayWCost;
	public GameObject editAName;
	public GameObject displayAName;
	public GameObject editAAC;
	public GameObject displayAAC;
	public GameObject editADex;
	public GameObject displayADex;
	public GameObject editAPen;
	public GameObject displayAPen;
	public GameObject editASpecial;
	public GameObject displayASpecial;
	public GameObject editAWeight;
	public GameObject displayAWeight;
	public GameObject editACost;
	public GameObject displayACost;
	
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
		editWName.GetComponent<InputField>().text = displayWName.GetComponent<Text>().text;
		editWDamage.GetComponent<InputField>().text = displayWDamage.GetComponent<Text>().text;
		editWCrit.GetComponent<InputField>().text = displayWCrit.GetComponent<Text>().text;
		editWSpecial.GetComponent<InputField>().text = displayWSpecial.GetComponent<Text>().text;
		editWWeight.GetComponent<InputField>().text = displayWWeight.GetComponent<Text>().text;
		editWCost.GetComponent<InputField>().text = displayWCost.GetComponent<Text>().text;
		editAName.GetComponent<InputField>().text = displayAName.GetComponent<Text>().text;
		editAAC.GetComponent<InputField>().text = displayAAC.GetComponent<Text>().text;
		editADex.GetComponent<InputField>().text = displayADex.GetComponent<Text>().text;
		editAPen.GetComponent<InputField>().text = displayAPen.GetComponent<Text>().text;
		editASpecial.GetComponent<InputField>().text = displayASpecial.GetComponent<Text>().text;
		editAWeight.GetComponent<InputField>().text = displayAWeight.GetComponent<Text>().text;
		editACost.GetComponent<InputField>().text = displayACost.GetComponent<Text>().text;
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
		displayWName.GetComponent<Text>().text = editWName.GetComponent<InputField>().text;
		displayWDamage.GetComponent<Text>().text = editWDamage.GetComponent<InputField>().text;
		displayWCrit.GetComponent<Text>().text = editWCrit.GetComponent<InputField>().text;
		displayWSpecial.GetComponent<Text>().text = editWSpecial.GetComponent<InputField>().text;
		displayWWeight.GetComponent<Text>().text = editWWeight.GetComponent<InputField>().text;
		displayWCost.GetComponent<Text>().text = editWCost.GetComponent<InputField>().text;
		displayAName.GetComponent<Text>().text = editAName.GetComponent<InputField>().text;
		displayAAC.GetComponent<Text>().text = editAAC.GetComponent<InputField>().text;
		displayADex.GetComponent<Text>().text = editADex.GetComponent<InputField>().text;
		displayAPen.GetComponent<Text>().text = editAPen.GetComponent<InputField>().text;
		displayASpecial.GetComponent<Text>().text = editASpecial.GetComponent<InputField>().text;
		displayAWeight.GetComponent<Text>().text = editAWeight.GetComponent<InputField>().text;
		displayACost.GetComponent<Text>().text = editACost.GetComponent<InputField>().text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
