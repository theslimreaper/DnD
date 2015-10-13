using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class Load_Character_Selection : MonoBehaviour {
    public GameObject Select_Character_Button;
    public GameObject Select_Character_Text;
    public string[] characters = null;
    public RectTransform ParentButton;
    public RectTransform ParentText;

	// Use this for initialization
	void Start () {
	}

    public void GetCharacters()
    {
        characters  = Directory.GetFiles(".","*.xml");
        for(int i = 0; i < characters.Length; i++)
        {
            GameObject characterButton = (GameObject)Instantiate(Select_Character_Button);
            GameObject characterText = characterButton.gameObject.transform.GetChild(0).gameObject;
            characterButton.transform.SetParent(ParentButton, false);
            //characterText.transform.SetParent(ParentText, false);
            characterButton.transform.localScale = new Vector3(1, 1, 1);
            characterText.transform.localScale = new Vector3(1, 1, 1);
            characterText.GetComponent<Text>().text = Path.GetFileNameWithoutExtension(characters[i]);
            if( i == 0)
            {
                characterButton.transform.position = new Vector3(ParentButton.transform.position.x, ParentButton.transform.position.y, -212);
                characterText.transform.position = new Vector3(ParentText.transform.position.x, ParentText.transform.position.y + 150, ParentText.transform.position.z);
            }
            else
            {
                characterButton.transform.position = new Vector3(ParentButton.transform.position.x, ParentButton.transform.position.y - (150*i), -212);
                characterText.transform.position = new Vector3(ParentText.transform.position.x, ParentText.transform.position.y + (150*i), ParentText.transform.position.z);
            }
 
            print(characterText.GetComponent<Text>().text);
            Button tempButton = characterButton.GetComponent<Button>();
            int position = i;

            tempButton.onClick.AddListener(() => SelectCharacter(position));
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
