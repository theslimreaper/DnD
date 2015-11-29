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
	float bonus;
	public void start()
	{
		if(Character_Info.characterLevel==null||Character_Info.characterLevel=="")
		{
			Character_Info.characterLevel="1";
		}
		bonus =(1f + System.Convert.ToInt32(Character_Info.characterLevel))/4f;
		bonus = Mathf.Ceil (bonus);
		BonusText.text="Bonus: +"+bonus.ToString();
	}
	public void promptForValue()
	{
		Popup.SetActive (true);
	}

	public void closePrompt(int keep)
	{
		if(newValue.text!=null&&newValue.text.Length!=0&&keep==1)
		{
			print (newValue.text);
			Proficiencies.Add(newValue.text);
			newValue.text="";
		}
		Popup.SetActive (false);
	}

	public void updateList()
	{
		//remove all old values
		foreach(Transform child in contentPane.transform) 
		{
			Destroy(child.gameObject);
		}
		//add all values in 
		for(int i=0;i<Proficiencies.Count;i++)
		{
			currentItem=Instantiate (ProficiencyPrefab, new Vector3(0,0,0),Quaternion.identity) as GameObject;
			currentItem.transform.parent=contentPane.transform;
			currentItem.GetComponent<Text>().text=Proficiencies[i];
			currentItem.transform.position= contentPane.transform.position;
			currentItem.transform.position=	new Vector3(currentItem.transform.position.x+91,currentItem.transform.position.y-27.5f-20f*i,currentItem.transform.position.z);
		}
	}
}
