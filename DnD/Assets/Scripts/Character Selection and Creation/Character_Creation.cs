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
    public GameObject characterName;
    public GameObject characterAvatar;
    public PointBuyCalculator pointBuy;
    public Button pointBuyButton;
    public Button rollingScoreButton;

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
        if(rollingScoreButton.interactable == false)
        {
            for (int i = 0; i < 6; i++)
            {
                if (RollingAbilityChoice.dropDowns[i].GetComponent<Dropdown>().value == 0)
                {
                    MessageBoxOK.ShowBox("Please ensure that each ability score has a corresponding stat!");
                    return;
                }
            }
        }
        else if(pointBuyButton.interactable == false)
        {
            if (PointBuyCalculator.PointBuyLeft < 0)
            {
                MessageBoxOK.ShowBox("Please ensure that the total number of remaining points is greater than or equal to 0!");
                return;
            }
        }
        if(characterName.GetComponent<InputField>().text == "")
        {
            MessageBoxOK.ShowBox("Please enter a name for the character!");
            return;
        }
        MessageBoxYN.ShowBox("Are you sure you want to confirm this character?");
        MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => confirmCharacter());
    }

    void confirmCharacter()
    {
        Character_Info.characterName = characterName.GetComponent<InputField>().text;
        Character_Info.characterAvatar = characterAvatar.GetComponent<Image>().sprite;
        Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver>();
        Save.SaveCharacterData();
        Application.LoadLevel("Screen Hub");
    }
}
