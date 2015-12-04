using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;


public class screenHubClassFeaturesController : MonoBehaviour {
	public GameObject classFeatsPage;
	public GameObject chosenFeatsPage;
	public GameObject listedFeature;
	public GameObject DropDownContent;
	public List<GameObject> spawnedItems= new List<GameObject>();
	bool firstPress=true;
	// Use this for initialization
	public void onClassFeatsClick()//go to class features
	{
		classFeatsPage.SetActive (true);
		chosenFeatsPage.SetActive (false);
		if (firstPress) {
			int i = 0;
			foreach (string name in Character_Info.characterClassFeaturesNames) {
				GameObject item = Instantiate (listedFeature, new Vector3 (listedFeature.transform.position.x, listedFeature.transform.position.y - 80 * i, listedFeature.transform.position.z), Quaternion.identity)as GameObject;
				spawnedItems.Add (item);
				item.transform.SetParent (DropDownContent.transform);
				item.transform.localScale = new Vector3 (1, 1, 1);
				item.transform.localPosition.Set (60, listedFeature.transform.position.y - 27 * i, 0);
				foreach (Transform child in item.transform) {
					if (child.name == "Label") {
						child.GetComponent<Text> ().text = Character_Info.characterClassFeaturesNames [i];
					}
				}
				item.GetComponent<LevelUpClassFeaturePopup> ().title = Character_Info.characterClassFeaturesNames [i];
				item.GetComponent<LevelUpClassFeaturePopup> ().Description = Character_Info.characterClassFeaturesDescriptions [i];
				i++;
			}
			listedFeature.SetActive(false);
			firstPress=false;
		}
	}
	public void onChosenFeatsClick()//go to feats
	{
		classFeatsPage.SetActive (false);
		chosenFeatsPage.SetActive (true);
	}
}
