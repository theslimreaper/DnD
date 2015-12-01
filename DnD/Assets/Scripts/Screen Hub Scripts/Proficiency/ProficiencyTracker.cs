using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProficiencyTracker : MonoBehaviour {
	public static List<string> Proficiencies = new List<string>();
	public GameObject contentPane;
	public GameObject Popup;
	public InputField newValue;
	public GameObject ProficiencyPrefab;
	public GameObject currentItem;
	public Text BonusText;
	float bonus=0;
	bool addDelete=true;

	public void start()
	{
		bonus = 0;
		if(Character_Info.characterLevel==null||Character_Info.characterLevel=="")
		{
			Character_Info.characterLevel="1";
		}
		bonus =(System.Convert.ToInt32(Character_Info.characterLevel))/4f;
		bonus = Mathf.Ceil (bonus);
		bonus++;
		BonusText.text="Bonus: +"+bonus.ToString();
	}
	public void promptForValue()
	{
		addDelete = true;
		Popup.SetActive (true);
	}
	public void promptForDelete()
	{
		addDelete = false;
		Popup.SetActive (true);
	}

	public void closePrompt(int keep)
	{
		if (addDelete == true) //if adding new value update proficiencies list
		{
			if (newValue.text != null && newValue.text.Length != 0 && keep == 1) {
				Proficiencies.Add (newValue.text);
				newValue.text = "";
			}
		}
		else//if removing the value look for it in the list
		{
			if (newValue.text != null && newValue.text.Length != 0 && keep == 1) {
				Proficiencies.Remove(newValue.text);
				newValue.text = "";
			}
		}
		Popup.SetActive (false);
	}

	public void updateList()
	{

			//remove all old values
			foreach (Transform child in contentPane.transform) {
				Destroy (child.gameObject);
			}
			//add all values in 
			for (int i=0; i<Proficiencies.Count; i++) {
				currentItem = Instantiate (ProficiencyPrefab, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				currentItem.transform.parent = contentPane.transform;
				currentItem.GetComponent<Text> ().text = Proficiencies [i];
				currentItem.transform.position = contentPane.transform.position;
				currentItem.transform.position = new Vector3 (currentItem.transform.position.x + 91, currentItem.transform.position.y - 27.5f - 20f * i, currentItem.transform.position.z);
			}

	}
}
