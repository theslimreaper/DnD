using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class Load_Character_Selection : MonoBehaviour {
    public GameObject Select_Character_Button;
    public GameObject Select_Character_Text;
    string[] characters = null;
    public GameObject ScrollView;
    List<GameObject> dynamicObjects = new List<GameObject>();
    public RectTransform ParentButton;
    static RectTransform ParentButtonDefault;
    public RectTransform ParentText;
    static RectTransform ParentRectDefault;
    static float ParentRectHeight;
    RectTransform ParentRect;
    float screenRatio = (float)Screen.height / (float)1080;

	// Use this for initialization
	void Start () {
        ParentButtonDefault = ParentButton;
        ParentRectDefault = ParentButtonDefault.GetComponent<RectTransform>();
        ParentRectHeight = ParentRectDefault.rect.height;
        ParentRect = ParentRectDefault;
	}

    public void GetCharacters()
    {
        characters  = Directory.GetFiles(".","*.xml");
        foreach( var item in dynamicObjects )
        {
            Destroy(item);
        }

        dynamicObjects.Clear();

        if(characters.Length > 0)
        {
            ScrollView.transform.position = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y, 0);
        }
        else
        {
            ScrollView.transform.position = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y, -10000);
        }


            for (int i = 0; i < characters.Length; i++)
            {
                GameObject characterButton = (GameObject)Instantiate(Select_Character_Button);
                GameObject characterText = characterButton.gameObject.transform.GetChild(0).gameObject;
                characterButton.transform.SetParent(ParentButton, false);
                //characterText.transform.SetParent(ParentText, false);
                characterButton.transform.localScale = new Vector3(0.4760417f, 0.4760417f, 0.4760417f);
                characterText.transform.localScale = new Vector3(4.760417f * 0.5f, 4.760417f * 0.5f, 4.760417f * 0.5f);
                characterText.GetComponent<Text>().text = Path.GetFileNameWithoutExtension(characters[i]);
                if (i == 0)
                {
                    characterButton.transform.position = new Vector3(ParentText.transform.position.x, ParentText.transform.position.y, -212);
                }
                else
                {
                    print(Screen.height);
                    print(screenRatio);
                    characterButton.transform.position = new Vector3(ParentText.transform.position.x, ParentText.transform.position.y - (150 * i * screenRatio), -212);
                }

                dynamicObjects.Add( characterButton );
                Button tempButton = characterButton.gameObject.GetComponent<Button>();
                int position = i;

                tempButton.onClick.AddListener(() => SelectCharacter(position));
            }

        if( dynamicObjects.Count > 0)
        {
            ParentRect.sizeDelta = new Vector2( ParentRectDefault.rect.width, (ParentRectHeight - ( dynamicObjects[characters.Length - 1].transform.position.y - ( 1.7f*dynamicObjects[characters.Length - 1].GetComponent<RectTransform>().rect.height )) ));
            Scrollbar ScrollBar = ScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
            ScrollBar.value = 1;
        }

    }

    void SelectCharacter(int position)
    {
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        string selected_file = characters[position];
        Load.LoadData(selected_file);
        Application.LoadLevel("Screen Hub");
    }
}
