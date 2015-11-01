using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class Character_Creation : MonoBehaviour {
    public Message_Handler MessageBoxOK;
    public Message_Handler MessageBoxYN;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void backPrompt()
    {
        MessageBoxYN.ShowBox("Are you sure you want to exit out of character creation?");
        MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => confirmBack());
    }

    void confirmBack()
    {
        Application.LoadLevel("Start Screen");
    }

    public void confirmCharacterPrompt()
    {
        MessageBoxYN.ShowBox("Are you sure you want to confirm this character?");
        MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => confirmCharacter());
    }

    void confirmCharacter()
    {
        Application.LoadLevel("Screen Hub");
    }
}
