using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Data_Handler : MonoBehaviour {
	public GameObject Class;
	public GameObject Race;
	//public GameObject Subrace;
	public GameObject Name;

	void Start(){
		ImportData ();
	}

	public void SaveData(){
		CollectData ();
		Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver> ();
		Save.SaveData (Character_Info.characterName);
		print ("Save successful!");
	}

	void CollectData(){
		Character_Info.characterClass = Class.GetComponent<InputField> ().text;
		Character_Info.characterRace = Race.GetComponent<InputField> ().text;
		//Character_Info.characterSubrace = Subrace.GetComponent<InputField> ().text;
		Character_Info.characterName = Name.GetComponent<InputField> ().text;
	}

	public void ImportData(){
		Class.GetComponent<InputField>().text = Character_Info.characterClass;
		Race.GetComponent<InputField>().text = Character_Info.characterRace;
		//Subrace.GetComponent<InputField>().text = Character_Info.characterSubrace;
		Name.GetComponent<InputField>().text = Character_Info.characterName;
	}
}
