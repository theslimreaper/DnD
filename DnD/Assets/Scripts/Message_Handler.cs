using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class Message_Handler : MonoBehaviour {
    public GameObject MessageText;
    public CanvasGroup MessageCanvasGroup;
    public GameObject MessagePanel;
	// Use this for initialization
	void Start () {
        HideBox();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Hide message box from user view
    public void HideBox()
    {
        MessageText.GetComponent<Text>().text = "";
        MessagePanel.SetActive(false);
        MessageCanvasGroup.alpha = 0;
        MessageCanvasGroup.interactable = false;
    }

	//Show message box in user view
    public void ShowBox(string message)
    {
        MessageText.GetComponent<Text>().text = message;
        MessagePanel.SetActive(true);
        MessageCanvasGroup.alpha = 1;
        MessageCanvasGroup.interactable = true;
	}

	//Remove all non-persistent events which have been attached to the selected button
	public void RemoveListeners( Button button ){
		button.onClick.RemoveAllListeners ();
	}
}
