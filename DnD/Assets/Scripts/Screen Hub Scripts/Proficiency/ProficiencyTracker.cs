using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProficiencyTracker : MonoBehaviour {
	public List<string> Proficiencies;
	public GameObject contentPane;
	public GameObject Popup;
	public InputField newValue;
	public GameObject ProficiencyPrefab;
	public GameObject currentItem;

	public void promptForValue()
	{
		Popup.SetActive (true);
	}

	public void closePrompt()
	{
		if(newValue.text!=null&&newValue.text.Length!=0)
		{
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
			Destroy(child);
		}
		//add all values in 
		for(int i=0;i<Proficiencies.Count;i++)
		{
			currentItem=Instantiate (ProficiencyPrefab, new Vector3(0,0,0),Quaternion.identity) as GameObject;
			currentItem.transform.parent=contentPane.transform;
			currentItem.GetComponent<Text>().text=Proficiencies[i];
			currentItem.transform.localPosition= new Vector3(0,160-i*20,0);
			//currentItem.GetComponent<RectTransform>().localPosition=new Vector3(0,160-i*20,0);
		}
	}
}
