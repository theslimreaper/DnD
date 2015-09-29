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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
