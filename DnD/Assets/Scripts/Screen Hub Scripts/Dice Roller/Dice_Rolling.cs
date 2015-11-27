using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dice_Rolling : MonoBehaviour {
	int diceAmount=0;
	int diceSides=0;
	int[] results;
	int total=0;
	string finalResults;
	public static int uses;
	public static int[] lastResults=new int[6];
	public static int lastSlotUsed=0;
	public GameObject FinalResultsText;
    public Message_Handler MessageBoxOK;
	// Use this for initialization
	public void RollDice()
	{
		diceAmount =System.Convert.ToInt32(GameObject.Find ("Amount of Dice").GetComponent<InputField> ().text);
		diceSides=System.Convert.ToInt32(GameObject.Find ("SideofDice").GetComponent<InputField> ().text);

		total = 0;

		results=new int[diceAmount];
		finalResults = "You Rolled: ";
		Random.seed=(int)(Time.time*100);

		for(int i=0;i<diceAmount;i++)
		{

			results[i]=Random.Range (1,diceSides+1);
			total+=results[i];
			finalResults+=results[i]+", ";
		}
		finalResults = finalResults.Substring (0, finalResults.Length - 2);
		finalResults += "\nTotalling to: " + total;

		MessageBoxOK.ShowBox(finalResults);



	}

	//used by the ability scores page. takes 4 roles and gets rid of the lowest
	public void RollD6SetText(int amount)
	{
		uses++;
		total = 0;
		string resultString="";
		int lowestValue = 6;
		results=new int[amount];
		Random.seed=(int)(Time.time*100+uses);

		for(int i=0;i<amount;i++)
		{
			
			results[i]=Random.Range (1,7);
			total+=results[i];
			resultString+=results[i]+" + ";
			print (results[i]);
			if(lowestValue>results[i])
			{
				lowestValue=results[i];
			}
		}
		resultString = resultString.Substring (0, resultString.Length-2);
		resultString += (" - " + lowestValue.ToString()+" (lowest)");
		total -= lowestValue;
		lastResults[lastSlotUsed] = total;
		lastSlotUsed ++;
		if(lastSlotUsed==6)
		{
			lastSlotUsed=0;
		}

		resultString += " = " + total.ToString();
		
		print (finalResults);
		this.gameObject.GetComponent<Text> ().text = resultString;
		
		
		
	}
}
