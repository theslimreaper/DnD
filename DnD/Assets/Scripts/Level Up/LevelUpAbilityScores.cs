using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpAbilityScores : MonoBehaviour {
	public GameObject AbilityScoresPage;
	public Dropdown DropDown1;
	public Text CurrentValue1;
	public Dropdown DropDown2;
	public Text CurrentValue2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
