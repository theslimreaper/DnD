using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class featureHolder : MonoBehaviour {
	public Text featureName;
	public Text featureDescription;
	public GameObject SelectedFeatPage;
	public GameObject FeatsListPage;
	public GameObject ClassFeaturePage;
	// Use this for initialization
	// Update is called once per frame
	public void acceptFeat(){
		ClassFeaturePage.SetActive (true);
		this.gameObject.SetActive (false);
	}
	public void cancelFeat(){
		SelectedFeatPage.SetActive (false);
		FeatsListPage.SetActive (true);
	}
}
