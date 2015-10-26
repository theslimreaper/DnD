using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RollingAbilityChoice : MonoBehaviour {
	public static GameObject[] dropDowns= new GameObject[6];
	public int dropDownNumber;
	int previousValue=0;
	int currentValue=0;
	void Start(){
		dropDowns [dropDownNumber-1] = this.gameObject;
	}

	public void CheckOtherScores()
	{

		previousValue = currentValue;
		currentValue = this.GetComponent<Dropdown> ().value;
		print (previousValue + "    " + currentValue);
		for (int i=0; i<6; i++) 
		{
			if(dropDowns[i].GetComponent<Dropdown>().value==this.GetComponent<Dropdown>().value&& i!=dropDownNumber-1 &&dropDowns[i].GetComponent<Dropdown>().value!=0 )
			{
				dropDowns[i].GetComponent<Dropdown>().value=0;
				AbilityScoreInitial.AbilityScores[i]=0;
				//print (i+" reset");
			}
			//AbilityScoreInitial.AbilityScores[i]=0;
		}
		if(previousValue!=0)
		{
			AbilityScoreInitial.AbilityScores [previousValue-1] = 0;
		}
		//print ("arrays use: " + (this.GetComponent<Dropdown> ().value - 1) + " and " + (dropDownNumber - 1));
		if(currentValue!=0)
		{
			AbilityScoreInitial.AbilityScores[this.GetComponent<Dropdown>().value-1]=Dice_Rolling.lastResults[dropDownNumber-1];
		}
		for (int i=0; i<6; i++) 
		{
			print (i+": "+AbilityScoreInitial.AbilityScores[i]);
		}
	}

	public void reroll()
	{
		this.GetComponent<Dropdown> ().value = 0;
	}
}
