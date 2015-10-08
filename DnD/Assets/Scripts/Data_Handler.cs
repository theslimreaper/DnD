using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Data_Handler : MonoBehaviour {
	public GameObject Class;
	public GameObject Race;
	//public GameObject Subrace;
	public GameObject Name;
	public GameObject Health;
	public GameObject Gender;
	public GameObject Alignment;
	public GameObject Height;
	public GameObject Weight;
	public GameObject CarryWeight;
	public GameObject Age;
	public GameObject Level;
	public GameObject MoveSpeed;
	public GameObject Languages;

	void Start(){
		ImportData ();
	}

	public void SaveData(){
		CollectData ();
		Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver> ();
		//Save.SaveData (Character_Info.characterName);
		Save.SaveData ("test");
		print ("Save successful!");
	}

	void CollectData(){
		Character_Info.characterClass = Class.GetComponent<Text> ().text;
		Character_Info.characterRace = Race.GetComponent<Text> ().text;
		//Character_Info.characterSubrace = Subrace.GetComponent<Text> ().text;
		//Character_Info.characterName = Name.GetComponent<Text> ().text ();
		Character_Info.characterHealth = Health.GetComponent<Text> ().text;
		Character_Info.characterGender = Gender.GetComponent<Text> ().text;
		Character_Info.characterAlignment = Alignment.GetComponent<Text> ().text;
		Character_Info.characterHeight = Height.GetComponent<Text> ().text;
		Character_Info.characterWeight = Weight.GetComponent<Text> ().text;
		Character_Info.characterCarryWeight = CarryWeight.GetComponent<Text> ().text;
		Character_Info.characterAge = Age.GetComponent<Text> ().text;
		Character_Info.characterLevel = Level.GetComponent<Text> ().text;
		Character_Info.characterMoveSpeed = MoveSpeed.GetComponent<Text> ().text;
		Character_Info.characterLanguages = Languages.GetComponent<Text> ().text;

	}

	public void ImportData(){
		Class.GetComponent<Text>().text = Character_Info.characterClass;
		Race.GetComponent<Text>().text = Character_Info.characterRace;
		//Subrace.GetComponent<Text>().text = Character_Info.characterSubrace;
		Name.GetComponent<Text> ().text = Character_Info.characterName;
		Health.GetComponent<Text> ().text = Character_Info.characterHealth;
		Gender.GetComponent<Text> ().text = Character_Info.characterGender;
		Alignment.GetComponent<Text> ().text = Character_Info.characterAlignment;
		Character_Info.characterAlignment = Alignment.GetComponent<Text> ().text;
		Height.GetComponent<Text> ().text = Character_Info.characterHeight;
		Weight.GetComponent<Text> ().text = Character_Info.characterWeight;
		CarryWeight.GetComponent<Text> ().text = Character_Info.characterCarryWeight;
		Age.GetComponent<Text> ().text = Character_Info.characterAge;
		Level.GetComponent<Text> ().text = Character_Info.characterLevel;
		MoveSpeed.GetComponent<Text> ().text = Character_Info.characterMoveSpeed;
		Languages.GetComponent<Text> ().text = Character_Info.characterLanguages;
	}
}
