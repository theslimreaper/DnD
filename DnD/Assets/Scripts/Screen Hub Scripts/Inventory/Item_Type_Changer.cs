using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item_Type_Changer : MonoBehaviour {
	int currentScreen;
	public CanvasGroup[] screenCanvasGroups;
    public GameObject waParent;
    public GameObject[] screens;
    public Dropdown itemDropDown;
    public Dropdown PPODropDown;
    public GameObject[] PPOItems;
    public CanvasGroup[] PPOItemsCanvas;
	// Use this for initialization
	void Start () {
            currentScreen = 0;
            SelectCurrentScreen(currentScreen);
            ChangePPOType(currentScreen);
            itemDropDown.onValueChanged.AddListener(delegate { SelectCurrentScreen(itemDropDown.value); });
            PPODropDown.onValueChanged.AddListener(delegate { ChangePPOType(PPODropDown.value); });
	}

	//Specifies which screen to show and which ones to hide
    public void SelectCurrentScreen( int position )
    {
		//For each screen
        for(int i = 0; i < screenCanvasGroups.Length; i++)
        {
            if( i == position )
            {
			//Show the screen if it has been specified as the current screen
                screenCanvasGroups[i].alpha = 1;
                screenCanvasGroups[i].interactable = true;
                screens[i].SetActive(true);
            }
            else
            {
			   //Hide all other screens
               screenCanvasGroups[i].alpha = 0;
               screenCanvasGroups[i].interactable = false;
               screens[i].SetActive(false);
            }
            if( i == 0 || i == 1 )
            {
                if (screenCanvasGroups[0].alpha == 1 || screenCanvasGroups[1].alpha == 1)
                {
                    waParent.GetComponent<CanvasGroup>().alpha = 1;
                    waParent.GetComponent<CanvasGroup>().interactable = true;
                    waParent.SetActive(true);
                }
                else
                {
                    waParent.GetComponent<CanvasGroup>().alpha = 0;
                    waParent.GetComponent<CanvasGroup>().interactable = false;
                    waParent.SetActive(false);
                }
            }
        }
    }

    public void ChangePPOType(int value)
    {
        for (int i = 0; i < PPOItemsCanvas.Length; i++)
        {
            if (i == value)
            {
                PPOItemsCanvas[i].alpha = 1;
                PPOItemsCanvas[i].interactable = true;
                PPOItems[i].SetActive(true);
            }
            else
            {
                PPOItemsCanvas[i].alpha = 0;
                PPOItemsCanvas[i].interactable = false;
                PPOItems[i].SetActive(false);
            }
        }
    }
    

}
