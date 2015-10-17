using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public void HideBox()
    {
        MessageText.GetComponent<Text>().text = "";
        MessagePanel.SetActive(false);
        MessageCanvasGroup.alpha = 0;
        MessageCanvasGroup.interactable = false;
    }

    public void ShowBox(string message)
    {
        MessageText.GetComponent<Text>().text = message;
        MessagePanel.SetActive(true);
        MessageCanvasGroup.alpha = 1;
        MessageCanvasGroup.interactable = true;
    }
}
