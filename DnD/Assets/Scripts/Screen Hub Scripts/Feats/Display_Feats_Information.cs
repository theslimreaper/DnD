using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Display_Feats_Information : MonoBehaviour
{
	public GameObject InfoScreen;
	public GameObject featScreen;
	public GameObject backgroundID;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void DisplayMode(){
		InfoScreen.SetActive (false);
		featScreen.SetActive (true);
	}
}

