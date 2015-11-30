using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;

public class Data_Handler : MonoBehaviour {
	public GameObject Class;
	public GameObject Race;
	public GameObject Subrace;
	public GameObject Name;
	public GameObject Health;
    public GameObject currHealth;
	public GameObject Gender;
	public GameObject Alignment;
	public GameObject Height;
	public GameObject Weight;
	public GameObject CarryWeight;
	public GameObject Age;
	public GameObject Level;
	public GameObject MoveSpeed;
	public GameObject Languages;
    public GameObject avatar;
    public GameObject copper;
    public GameObject silver;
    public GameObject electrum;
    public GameObject gold;
    public GameObject platinum;
    public GameObject Str;
    public GameObject Dex;
    public GameObject Con;
    public GameObject Int;
    public GameObject Wis;
    public GameObject Cha;

    void Start(){
		ImportData ();
	}

	public void SaveData(){
		CollectData ();
		Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver> ();
		Save.SaveCharacterData ();
	}

	void CollectData(){
		Character_Info.characterClass = Class.GetComponent<InputField> ().text;
		Character_Info.characterRace = Race.GetComponent<InputField> ().text;
		Character_Info.characterSubrace = Subrace.GetComponent<InputField> ().text;
		Character_Info.characterName = Name.GetComponent<InputField> ().text;
		Character_Info.characterHealth = Health.GetComponent<InputField> ().text;
        Character_Info.characterCurrHealth = currHealth.GetComponent<InputField>().text;
        Character_Info.characterGender = Gender.GetComponent<InputField> ().text;
		Character_Info.characterAlignment = Alignment.GetComponent<InputField> ().text;
		Character_Info.characterHeight = Height.GetComponent<InputField> ().text;
		Character_Info.characterWeight = Weight.GetComponent<InputField> ().text;
		Character_Info.characterCarryWeight = CarryWeight.GetComponent<InputField> ().text;
		Character_Info.characterAge = Age.GetComponent<InputField> ().text;
		Character_Info.characterLevel = Level.GetComponent<InputField> ().text;
		Character_Info.characterMoveSpeed = MoveSpeed.GetComponent<InputField> ().text;
		Character_Info.characterLanguages = Languages.GetComponent<InputField> ().text;
        Character_Info.characterAvatar = avatar.GetComponent<Image>().sprite;
        Character_Info.copper = Convert.ToInt32(copper.GetComponent<InputField>().text);
        Character_Info.silver = Convert.ToInt32(silver.GetComponent<InputField>().text);
        Character_Info.electrum = Convert.ToInt32(electrum.GetComponent<InputField>().text);
        Character_Info.gold = Convert.ToInt32(gold.GetComponent<InputField>().text);
        Character_Info.platinum = Convert.ToInt32(platinum.GetComponent<InputField>().text);
        AbilityScoreInitial.AbilityScores[0] = Convert.ToInt32(Str.GetComponent<InputField>().text);
        AbilityScoreInitial.AbilityScores[1] = Convert.ToInt32(Dex.GetComponent<InputField>().text);
        AbilityScoreInitial.AbilityScores[2] = Convert.ToInt32(Con.GetComponent<InputField>().text);
        AbilityScoreInitial.AbilityScores[3] = Convert.ToInt32(Int.GetComponent<InputField>().text);
        AbilityScoreInitial.AbilityScores[4] = Convert.ToInt32(Wis.GetComponent<InputField>().text);
        AbilityScoreInitial.AbilityScores[5] = Convert.ToInt32(Cha.GetComponent<InputField>().text);

    }

	public void ImportData(){
		Class.GetComponent<InputField>().text = Character_Info.characterClass;
		Race.GetComponent<InputField>().text = Character_Info.characterRace;
		Subrace.GetComponent<InputField>().text = Character_Info.characterSubrace;
		Name.GetComponent<InputField> ().text = Character_Info.characterName;
		Health.GetComponent<InputField> ().text = Character_Info.characterHealth;
        currHealth.GetComponent<InputField>().text = Character_Info.characterCurrHealth;
        Gender.GetComponent<InputField> ().text = Character_Info.characterGender;
		Alignment.GetComponent<InputField> ().text = Character_Info.characterAlignment;
		Height.GetComponent<InputField> ().text = Character_Info.characterHeight;
		Weight.GetComponent<InputField> ().text = Character_Info.characterWeight;
		CarryWeight.GetComponent<InputField> ().text = Character_Info.characterCarryWeight;
		Age.GetComponent<InputField> ().text = Character_Info.characterAge;
		Level.GetComponent<InputField> ().text = Character_Info.characterLevel;
		MoveSpeed.GetComponent<InputField> ().text = Character_Info.characterMoveSpeed;
		Languages.GetComponent<InputField> ().text = Character_Info.characterLanguages;
        avatar.GetComponent<Image>().sprite = Character_Info.characterAvatar;
        copper.GetComponent<InputField>().text = Convert.ToString(Character_Info.copper);
        silver.GetComponent<InputField>().text = Convert.ToString(Character_Info.silver);
        electrum.GetComponent<InputField>().text = Convert.ToString(Character_Info.electrum);
        gold.GetComponent<InputField>().text = Convert.ToString(Character_Info.gold);
        platinum.GetComponent<InputField>().text = Convert.ToString(Character_Info.platinum);
        Str.GetComponent<InputField>().text = Convert.ToString(AbilityScoreInitial.AbilityScores[0]);
        Dex.GetComponent<InputField>().text = Convert.ToString(AbilityScoreInitial.AbilityScores[1]);
        Con.GetComponent<InputField>().text = Convert.ToString(AbilityScoreInitial.AbilityScores[2]);
        Int.GetComponent<InputField>().text = Convert.ToString(AbilityScoreInitial.AbilityScores[3]);
        Wis.GetComponent<InputField>().text = Convert.ToString(AbilityScoreInitial.AbilityScores[4]);
        Cha.GetComponent<InputField>().text = Convert.ToString(AbilityScoreInitial.AbilityScores[5]);
    }
}
