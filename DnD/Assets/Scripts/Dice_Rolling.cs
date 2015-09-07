using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dice_Rolling : MonoBehaviour {
	int diceAmount=0;
	int diceSides=0;
	int[] results;
	int total=0;
	string finalResults;
	public GameObject FinalResultsText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RollDice()
	{
		diceAmount =System.Convert.ToInt32(GameObject.Find ("Amount of Dice").GetComponent<InputField> ().text);
		diceSides=System.Convert.ToInt32(GameObject.Find ("SideofDice").GetComponent<InputField> ().text);
		print (diceAmount + " " + diceSides);

		total = 0;

		results=new int[diceAmount];
		finalResults = "You Rolled: ";
		Random.seed=(int)(Time.time*100);

		for(int i=0;i<diceAmount;i++)
		{

			results[i]=Random.Range (1,diceSides+1);
			total+=results[i];
			finalResults+=results[i]+", ";
			print (results[i]);
		}
		finalResults = finalResults.Substring (0, finalResults.Length - 2);
		finalResults += "\nTotalling to: " + total;

		print (finalResults);
		FinalResultsText.GetComponent<Text> ().text = finalResults;



	}

}
