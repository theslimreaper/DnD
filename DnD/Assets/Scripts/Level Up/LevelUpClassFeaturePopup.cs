using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpClassFeaturePopup : MonoBehaviour {
	public int featNumber;
	public Button descriptionButton;
	public GameObject DescriptionBox;
	public string title;
	public string Description;
	public Text TitleText;
	public Text DescriptionText;
	public void onButtonClick()
	{
		DescriptionBox.SetActive (true);	
		TitleText.text = title;
		DescriptionText.text = Description;
	}
	public void onCloseClick(){
		DescriptionBox.SetActive (false);
	}

}
