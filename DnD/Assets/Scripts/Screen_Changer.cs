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
        currentScreen = 0;
        SelectCurrentScreen(currentScreen);
	}
	
    public void SelectCurrentScreen( int position )
    {
        for(int i = 0; i < screenCanvasGroups.Length; i++)
        {
            if( i == position )
            {
                screenCanvasGroups[i].alpha = 1;
                screenCanvasGroups[i].interactable = true;
                screens[i].SetActive(true);
                headerButtons[i].interactable = false;
            }
            else
            {
               screenCanvasGroups[i].alpha = 0;
               screenCanvasGroups[i].interactable = false;
                screens[i].SetActive(false);
                headerButtons[i].interactable = true;
            }
        }
    }
    

}
