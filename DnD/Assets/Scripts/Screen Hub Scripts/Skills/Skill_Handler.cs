using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Skill_Handler : MonoBehaviour {
    public static string[] skillNames = {"Acrobatics","Animal Handling","Arcana","Athletics","Deception","History",
                                        "Insight","Intimidation","Investigation","Medicine","Nature","Perception",
                                        "Performance", "Persuasion", "Relgion", "Sleight of Hand", "Stealth", "Survival"};
    public bool[] trained = new bool[18];
    public static int[] values = new int[18];
    public int[] bonuses = new int[18];
	public int skillPointsToSpend=6;
	public int[] Changes = new int[18];
	public GameObject[] TextDisplay= new GameObject[18];
	public void addSkill(int skillNumber)
	{
		print ("Up Pressed");
		if (skillPointsToSpend>0)
		{
			values[skillNumber]++;
			Changes[skillNumber]++;
			skillPointsToSpend--;
			TextDisplay[skillNumber].GetComponent<Text>().text=values[skillNumber].ToString();
			print ("points updated");
		}
	}

	public void subtractSkill(int skillNumber)
	{
		print ("Down Pressed");
		if(Changes[skillNumber]>0)
		{
			values[skillNumber]--;
			Changes[skillNumber]--;
			skillPointsToSpend++;
			print ("points updated");
			TextDisplay[skillNumber].GetComponent<Text>().text=values[skillNumber].ToString();
		}
	}
}
