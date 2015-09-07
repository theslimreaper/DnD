using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dice_Rolling : MonoBehaviour {
	int diceAmount=0;
	int diceSides=0;
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
	}

}
