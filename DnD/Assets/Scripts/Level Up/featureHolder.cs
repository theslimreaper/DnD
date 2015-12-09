using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class featureHolder : MonoBehaviour {
	public Text featureName;
	public Text featureDescription;
	public GameObject SelectedFeatPage;
	public GameObject FeatsListPage;
	public GameObject ClassFeaturePage;
	public GameObject BackgroundID;
	// Use this for initialization
	// Update is called once per frame
	public void acceptFeat(){
		ClassFeaturePage.SetActive (true);
		this.gameObject.SetActive (false);
		Character_Info.characterFeats.Add (BackgroundID.GetComponent<Text> ().text);
	}
	public void cancelFeat(){
		SelectedFeatPage.SetActive (false);
		FeatsListPage.SetActive (true);
	}
}
