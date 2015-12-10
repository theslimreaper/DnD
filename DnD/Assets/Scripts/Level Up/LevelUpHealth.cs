using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpHealth : MonoBehaviour {
	int hd;
	string xmlClass;
	string xmlResultValue;
	public GameObject HealthPage;
	public Text healthExplanation;
	public InputField healthResultsInput;
	public Text conModifier;
	public int con;
	public Text FinalResult;
	public GameObject abilityScorePage;
	public GameObject classFeaturePage;
	public Text AbilityScoreModifierText;
	void Start()
	{
		UpdateHealth ();
		if (Character_Info.characterHealth == null || Character_Info.characterHealth == "")
			Character_Info.characterHealth = "0";
	}


	public void UpdateHealth()
	{
		if (AbilityScoreInitial.AbilityScores[2] >= 10)//take con modifier result and display
		{
			conModifier.text= "+"+((AbilityScoreInitial.AbilityScores[2] - 10) / 2).ToString();
			con= ((AbilityScoreInitial.AbilityScores[2] - 10) / 2);
		}
		else
		{
			conModifier.text= ((AbilityScoreInitial.AbilityScores[2] - 11) / 2).ToString();
			con=((AbilityScoreInitial.AbilityScores[2] - 11) / 2);
		}


		xmlClass = "<classname>" + Character_Info.characterClass + "</classname>";//look at each class
		XML_Loader xmlLoader = ScriptableObject.CreateInstance<XML_Loader> ();//load xml
		List<string> XmlResult  = new List<string> ();

		if(Settings_Screen.is_online==true)//look at setting to determine if you should use online xml or local copy
		{
			XmlResult = xmlLoader.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classes.xml","class" );
		}
		else
		{
			XmlResult = xmlLoader.LoadInnerXmlFromFile("..\\XML Files/Character Features/classes.xml", "class");
		}

		foreach(var item in XmlResult)//search through class list to find the players class
		{	
			if(item.Contains(xmlClass))//when found look at the hit dice tag for that class and pull the value
			{
				xmlResultValue=item.Substring(item.IndexOf("<hd>")+4,(item.IndexOf("</hd>")-item.IndexOf("<hd>")-4));//find the health line for that class
				break;
			}
		}
		healthExplanation.text = "As a " + Character_Info.characterClass + " you roll a d" + xmlResultValue + " for health";
		hd = System.Convert.ToInt32 (xmlResultValue);
		healthResultsInput.text = (Random.Range (1, hd)).ToString();
		FinalResult.text = "= " + (con + System.Convert.ToInt32 (healthResultsInput.text));
	}
	public void FinishedHealth()//adds the results of the health page to max health and adds con bonus
	{
		int bonus=0;
		if (System.Convert.ToInt32 (healthResultsInput.text)>0&&System.Convert.ToInt32 (healthResultsInput.text)<12) 
		{
			bonus+=System.Convert.ToInt32 (healthResultsInput.text);	//adds the hit die result
			if (AbilityScoreInitial.AbilityScores[2] >= 10)//take con modifier result
			{
				bonus += ((AbilityScoreInitial.AbilityScores[2] - 10) / 2);
			}
			else
			{
				bonus += ((AbilityScoreInitial.AbilityScores[2] - 11) / 2);
			}

			Character_Info.characterHealth= (System.Convert.ToInt32(Character_Info.characterHealth)+bonus).ToString();
		}

		HealthPage.SetActive (false);
		print (Character_Info.characterLevel);
		if (Character_Info.characterLevel == "4"|| Character_Info.characterLevel == "8" || Character_Info.characterLevel == "12" || Character_Info.characterLevel == "16" || Character_Info.characterLevel == "19")
		{
			AbilityScoreModifierText.text="For reaching level "+Character_Info.characterLevel+" you can either:\ngain a new feat or\nincrease ability scores";
			abilityScorePage.SetActive (true);
		}
		else
			classFeaturePage.SetActive (true);
	}
	public void onHealthInputUpdate()
	{
		FinalResult.text = "= " + (con + System.Convert.ToInt32 (healthResultsInput.text));
	}


}
