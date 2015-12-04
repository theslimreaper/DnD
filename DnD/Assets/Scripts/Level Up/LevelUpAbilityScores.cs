using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpAbilityScores : MonoBehaviour {
	public GameObject Page1;
	public GameObject AbilityScoresPage;
	public GameObject featspage;
	public GameObject ClassFeaturesPage;
	public Dropdown DropDown1;
	public Text CurrentValue1;
	public Dropdown DropDown2;
	public Text CurrentValue2;
	// Use this for initialization
	public void openAbilityScorePage()
	{
		Page1.SetActive (false);
		AbilityScoresPage.SetActive (true);
	}
	public void openFeatsPage(){
		Page1.SetActive (false);
		featspage.SetActive (true);
	}
	public void UpdateScores()//called once done on the screen to increase the two listed values by one
	{
		AbilityScoreInitial.AbilityScores [DropDown1.value]++;
		AbilityScoreInitial.AbilityScores [DropDown2.value]++;
		AbilityScoresPage.SetActive (false);
	}
	public void UpdateCurrentStatShown()//updates the text to show the current value of the stat they want to upgrade
	{
		CurrentValue1.text="Before Upgrade: "+AbilityScoreInitial.AbilityScores[DropDown1.value];
		CurrentValue2.text="Before Upgrade: "+AbilityScoreInitial.AbilityScores[DropDown2.value];
	}
	public void openClassFeaturesPage()
	{
		Page1.SetActive (false);
		featspage.SetActive (false);
		AbilityScoresPage.SetActive (false);
		ClassFeaturesPage.SetActive (true);
	}
	
}
