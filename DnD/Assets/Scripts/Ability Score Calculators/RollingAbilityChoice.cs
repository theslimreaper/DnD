using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RollingAbilityChoice : MonoBehaviour {
	public static GameObject[] dropDowns= new GameObject[6];
	public static Text[] FinalResults = new Text[6];
	public static InputField[] RacialResult=new InputField[6];
	public int dropDownNumber;
	int previousValue=0;
	int currentValue=0;
	void Start(){
		string temp;
		dropDowns [dropDownNumber-1] = this.gameObject;
		temp = "Final Result "+dropDownNumber.ToString();
		FinalResults [dropDownNumber - 1] = GameObject.Find (temp).GetComponent<Text>();
		temp = "Racial Modifier "+dropDownNumber.ToString();
		RacialResult [dropDownNumber - 1] = GameObject.Find (temp).GetComponent<InputField>();
	}

	public void CheckOtherScores()
	{

		previousValue = currentValue;
		currentValue = this.GetComponent<Dropdown> ().value;
		//print (previousValue + "    " + currentValue);
		for (int i=0; i<6; i++) 
		{
			if(dropDowns[i].GetComponent<Dropdown>().value==this.GetComponent<Dropdown>().value&& i!=dropDownNumber-1 &&dropDowns[i].GetComponent<Dropdown>().value!=0 )
			{
				dropDowns[i].GetComponent<Dropdown>().value=0;
				FinalResults[i].text="0";
				RacialResult[i].text="+0";
				AbilityScoreInitial.AbilityScores[i]=0;
			}
		}
		if(previousValue!=0)
		{
			AbilityScoreInitial.AbilityScores [previousValue-1] = 0;
		}
		if(currentValue!=0)
		{
			AbilityScoreInitial.AbilityScores[this.GetComponent<Dropdown>().value-1]=Dice_Rolling.lastResults[dropDownNumber-1];
			FinalResults[dropDownNumber-1].text=AbilityScoreInitial.AbilityScores[this.GetComponent<Dropdown>().value-1].ToString();
		}
	/*	for (int i=0; i<6; i++) 
		{
			print (i+": "+AbilityScoreInitial.AbilityScores[i]);
		}*/
	}

	public void reroll()
	{
		for(int i=0;i<6;i++)
		{
			dropDowns[i].GetComponent<Dropdown>().value=0;
			FinalResults[i].text="0";
			RacialResult[i].text="+0";
		}
	}
}
