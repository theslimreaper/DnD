﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load_Character_Info : MonoBehaviour {
    public GameObject Class;
	// Use this for initialization
	void Start () {

        Class.GetComponent<InputField>().text = Character_Info.characterClass;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
