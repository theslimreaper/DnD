using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public void LevelDropdown ()
	{
		if (dropdownValue.GetComponent<Dropdown>().value == 0)
		{
			zeroLevel.SetActive (true);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}

		else if (dropdownValue.GetComponent<Dropdown>().value == 1)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (true);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 2)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (true);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 3)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (true);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 4)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (true);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 5)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (true);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 6)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (true);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 7)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (true);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 8)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (true);
			ninthLevel.SetActive (false);
		}
		
		else if (dropdownValue.GetComponent<Dropdown>().value == 9)
		{
			zeroLevel.SetActive (false);
			firstLevel.SetActive (false);
			secondLevel.SetActive (false);
			thirdLevel.SetActive (false);
			fourthLevel.SetActive (false);
			fifthLevel.SetActive (false);
			sixthLevel.SetActive (false);
			seventhLevel.SetActive (false);
			eighthLevel.SetActive (false);
			ninthLevel.SetActive (true);
		}
	}
}

