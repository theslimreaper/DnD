using UnityEngine;
using System.Collections;

public class Spells_Dropdown_Handler : MonoBehaviour
{
	public GameObject zeroLevel;
	public GameObject firstLevel;
	public GameObject secondLevel;
	public GameObject thirdLevel;
	public GameObject fourthLevel;
	public GameObject fifthLevel;
	public GameObject sixthLevel;
	public GameObject seventhLevel;
	public GameObject eighthLevel;
	public GameObject ninthLevel;
	public GameObject dropdownValue;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	// Function for swapping spell level
	void LevelDropdown ()
	{
		if (dropdownValue.GetComponent<InputField>().text == "0th Level Spells")
		{
			zeroLevel.setActive (true);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}

		else if (dropdownValue.GetComponent<InputField>().text == "1st Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (true);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "2nd Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (true);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "3rd Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (true);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "4th Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (true);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "5th Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (true);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "6th Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (true);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "7th Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (true);
			eighthLevel.setActive (false);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "8th Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (true);
			ninthLevel.setActive (false);
		}
		
		else if (dropdownValue.GetComponent<InputField>().text == "9th Level Spells")
		{
			zeroLevel.setActive (false);
			firstLevel.setActive (false);
			secondLevel.setActive (false);
			thirdLevel.setActive (false);
			fourthLevel.setActive (false);
			fifthLevel.setActive (false);
			sixthLevel.setActive (false);
			seventhLevel.setActive (false);
			eighthLevel.setActive (false);
			ninthLevel.setActive (true);
		}
	}
}

