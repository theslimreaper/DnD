using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Screen_Changer : MonoBehaviour {
	int currentScreen;
	public CanvasGroup[] screenCanvasGroups;
    public GameObject[] screens;
    public Button[] headerButtons;
	// Use this for initialization
	void Start () {
		//Set current screen to Character Overview screen
        currentScreen = 0;
        SelectCurrentScreen(currentScreen);
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
				//Disable the header button which corresponds to the current screen
                headerButtons[i].interactable = false;
            }
            else
            {
			   //Hide all other screens
               screenCanvasGroups[i].alpha = 0;
               screenCanvasGroups[i].interactable = false;
               screens[i].SetActive(false);
			   //Enable the header buttons for all screens which are not the current screen
               headerButtons[i].interactable = true;
            }
        }
    }
    

}
