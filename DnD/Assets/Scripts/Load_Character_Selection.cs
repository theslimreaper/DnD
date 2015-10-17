using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Load_Character_Selection : MonoBehaviour {
    public GameObject Select_Character_Button;
    public GameObject Select_Character_Text;
    string[] characters = null;
    public GameObject ScrollView;
	public Message_Handler MessageBoxYN;
	public Message_Handler MessageBoxOK;
    public static List<GameObject> dynamicObjects = new List<GameObject>();
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

	//Get a list of loadable characters from the xml files in the "Saved Characters" subfolder
    public void GetCharacters()
    {
		//If the saved characters folder does not exist, output a message stating no saved characters were found
		if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Saved Characters"))){
			MessageBoxOK.ShowBox ("No saved characters were found!");
		}
		else{
		//Otherwise, get all saved characters and empty out the list of saved characters
        characters  = Directory.GetFiles("./Saved Characters","*.xml");
        DeleteLoadedCharacters();
		
		//If no saved characters are found, output a message to the user
		if (!(characters.Length > 0)) {
			MessageBoxOK.ShowBox ("No saved characters were found!");
		} else {
			//Otherwise, dynamically add buttons, one for each character, and place these buttons in a vertical list format inside a scroll view
			ScrollView.transform.position = new Vector3 (ScrollView.transform.position.x, ScrollView.transform.position.y, 0);

			for (int i = 0; i < characters.Length; i++) {
				GameObject characterButton = (GameObject)Instantiate (Select_Character_Button);
				GameObject characterText = characterButton.gameObject.transform.GetChild (0).gameObject;
				characterButton.transform.SetParent (ParentButton, false);
				characterButton.transform.localScale = new Vector3 (0.4760417f, 0.4760417f, 0.4760417f);
				characterText.transform.localScale = new Vector3 (4.760417f * 0.5f, 4.760417f * 0.5f, 4.760417f * 0.5f);
				characterText.GetComponent<Text> ().text = PeekAtCharacher (characters [i]);
				if (i == 0) {
					characterButton.transform.position = new Vector3 (ParentText.transform.position.x, ParentText.transform.position.y, -212);
				} else {
					characterButton.transform.position = new Vector3 (ParentText.transform.position.x, ParentText.transform.position.y - (150 * i * screenRatio), -212);
				}

				dynamicObjects.Add (characterButton);
				Button tempButton = characterButton.gameObject.GetComponent<Button> ();
				int position = i;
				
				//If the user is in the main screen, then add an event to choose the character to load to the selected button
				if (Application.loadedLevelName == "Start Screen") {
					tempButton.onClick.AddListener (() => SelectCharacter (position));
				} else {
				//Otherwise, bring up a message stating unsaved data will be lost, and have the character be chosen when the user specifies to continue
					tempButton.onClick.AddListener (() => MessageBoxYN.ShowBox ("WARNING: Loading another character will result in the loss of unsaved changes for the current character! Continue?"));
					tempButton.onClick.AddListener (() => (MessageBoxYN.gameObject.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.GetComponent<Button> ().onClick.AddListener (() => SelectCharacter (position))));
				}
			}
		}
		}

        if( dynamicObjects.Count > 0)
        {
            ParentRect.sizeDelta = new Vector2( ParentRectDefault.rect.width, (ParentRectHeight - ( dynamicObjects[characters.Length - 1].transform.position.y - ( 1.7f*dynamicObjects[characters.Length - 1].GetComponent<RectTransform>().rect.height )) ));
            Scrollbar ScrollBar = ScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
            ScrollBar.value = 1;
        }

    }

	//Load the selected character
    void SelectCharacter(int position)
    {
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        string selected_file = characters[position];
        Load.LoadData(selected_file);
        Application.LoadLevel("Screen Hub");
    }

	//Peek inside the saved character file so specific information can be displayed about the character in the list of loadable characters
    string PeekAtCharacher(string filename)
    {
        string line = "";
        string input_file = filename;
        string output_file = "temp.xml";
        List<string> keyList = new List<string>();
        List<string> elemList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();
        string characterInfo = "";

        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);

        //Open / read the selected (encrypted) character file and decrypt it, then write the decrypted information to a temporary xml file
        FileStream decrypted_file = new FileStream(input_file, FileMode.Open);
        FileStream temp_file = new FileStream(output_file, FileMode.Create);
        CryptoStream cryptography_stream = new CryptoStream(decrypted_file, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
        using (MemoryStream msDecrypt = new MemoryStream())
        {
            using (StreamReader srDecrypt = new StreamReader(cryptography_stream))
            {
                using (StreamWriter swTemp = new StreamWriter(temp_file))
                {
                    while ((line = srDecrypt.ReadLine()) != null)
                    {
                        swTemp.WriteLine(line);
                    }
                }
            }
        }
        cryptography_stream.Close();
        decrypted_file.Close();

        //Call functions to load data from temporary xml file into specified game objects
        elemList = XML.LoadInnerXmlFromFile(output_file, "charactername");
        foreach (var item in elemList)
        {
            characterInfo = item + " -";
        }
        elemList.Clear();

        elemList = XML.LoadInnerXmlFromFile(output_file, "characterlevel");
        foreach (var item in elemList)
        {
            characterInfo = characterInfo + " Lv. " + item;
        }
        elemList.Clear();

        elemList = XML.LoadInnerXmlFromFile(output_file, "charactersubrace");
        foreach (var item in elemList)
        {
            characterInfo = characterInfo +  " " + item;
        }
        elemList.Clear();

        elemList = XML.LoadInnerXmlFromFile(output_file, "characterrace");
        foreach (var item in elemList)
        {
            characterInfo = characterInfo + " " + item;
        }
        elemList.Clear();

        elemList = XML.LoadInnerXmlFromFile(output_file, "characterclass");
        foreach (var item in elemList)
        {
            characterInfo = characterInfo + " " + item;
        }
        elemList.Clear();

        //Delete the temporary xml file
        File.Delete(output_file);

        return characterInfo;
    }

	//Destroy all dynamically created objects for the list of characters
    public void DeleteLoadedCharacters()
    {
        foreach (var item in dynamicObjects)
        {
            Destroy(item);
        }

        dynamicObjects.Clear();

        ScrollView.transform.position = new Vector3(ScrollView.transform.position.x, ScrollView.transform.position.y, -10000);
    }
    
}
