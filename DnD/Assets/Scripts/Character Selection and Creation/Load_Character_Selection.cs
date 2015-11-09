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
    List<string> characters = new List<string>();
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
	Scrollbar ScrollBar;
    public AudioSource audioSource;
    public AudioClip audioClipNext;
    public AudioClip audioClipAlert;

	// Use this for initialization
	void Start () {
        ParentButtonDefault = ParentButton;
        ParentRectDefault = ParentButtonDefault.GetComponent<RectTransform>();
        ParentRectHeight = ParentRectDefault.rect.height;
        ParentRect = ParentRectDefault;
		ScrollBar = ScrollView.gameObject.transform.GetChild(1).GetComponent<Scrollbar>();
	}

	//Get a list of loadable characters from the xml files in the "Saved Characters" subfolder
    public void GetCharacters()
	{
		ScrollBar.value = 0;
		ParentRect.sizeDelta = new Vector2( ParentRectDefault.rect.width, 0);
		//If the saved characters folder does not exist, output a message stating no saved characters were found
		if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Saved Data")) || (!File.Exists((Path.Combine(Directory.GetCurrentDirectory(), "Saved Data/characters.xml"))))){
			MessageBoxOK.ShowBox ("No saved characters were found!");
		}
		else{
		//Otherwise, get all saved characters and empty out the list of saved characters
            characters.Clear();
            Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
            characters = Load.LoadCharacterIDs();
        DeleteLoadedCharacters();
		//If no saved characters are found, output a message to the user
		if (!(characters.Count > 0)) {
			MessageBoxOK.ShowBox ("No saved characters were found!");
		} else {
			//Otherwise, dynamically add buttons, one for each character, and place these buttons in a vertical list format inside a scroll view
			ScrollView.transform.position = new Vector3 (ScrollView.transform.position.x, ScrollView.transform.position.y, 0);
            int i = 0;
			foreach(var item in characters) {
				GameObject characterButton = (GameObject)Instantiate (Select_Character_Button);
				GameObject characterText = characterButton.gameObject.transform.GetChild (0).gameObject;
				characterButton.transform.SetParent (ParentButton, false);
				characterButton.transform.localScale = new Vector3 (0.4760417f, 0.4760417f, 0.4760417f);
				characterText.transform.localScale = new Vector3 (4.760417f * 0.5f, 4.760417f * 0.5f, 4.760417f * 0.5f);
				characterText.GetComponent<Text> ().text = PeekAtCharacher (Convert.ToInt32(characters [i]));
				if (i == 0) {
					characterButton.transform.position = new Vector3 (ParentText.transform.position.x, ParentText.transform.position.y, -212);
				} else {
					characterButton.transform.position = new Vector3 (ParentText.transform.position.x, ParentText.transform.position.y - (150 * i * screenRatio), -212);
				}
				dynamicObjects.Add (characterButton);
				Button tempButton = characterButton.gameObject.GetComponent<Button> ();
                int position = Convert.ToInt32(characters[i]);
				//If the user is in the main screen, then add an event to choose the character to load to the selected button
				if (Application.loadedLevelName == "Start Screen") {
                    tempButton.onClick.AddListener(delegate { audioSource.PlayOneShot(audioClipNext); });
					tempButton.onClick.AddListener (() => SelectCharacter (position));
				} else {
				//Otherwise, bring up a message stating unsaved data will be lost, and have the character be chosen when the user specifies to continue
                    tempButton.onClick.AddListener(delegate { audioSource.PlayOneShot(audioClipAlert); });
					tempButton.onClick.AddListener (() => MessageBoxYN.ShowBox ("WARNING: Loading another character will result in the loss of unsaved changes for the current character! Continue?"));
					tempButton.onClick.AddListener (() => (MessageBoxYN.gameObject.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.GetComponent<Button> ().onClick.AddListener (() => SelectCharacter (position))));
                }
                i++;
			}
		}
		}

        if( dynamicObjects.Count > 0)
        {
            ParentRect.sizeDelta = new Vector2( ParentRectDefault.rect.width, (ParentRectHeight - ( dynamicObjects[characters.Count - 1].transform.position.y - ( 1.7f*dynamicObjects[characters.Count - 1].GetComponent<RectTransform>().rect.height )) ));
            ScrollBar.value = 1;
        }

    }

	//Load the selected character
    void SelectCharacter(int position)
    {
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        Load.LoadCharacterData(position);
        Application.LoadLevel("Screen Hub");
    }

	//Peek inside the saved character file so specific information can be displayed about the character in the list of loadable characters
    string PeekAtCharacher(int position)
    {
        string line = "";
        string input_file = "./Saved Data/characters.xml";
        string output_file = "temp.xml";
        List<string> keyList = new List<string>();
        List<string> elemList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();
        string characterInfo = "";
        string tagName = "";

        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);

        //Open / read the selected (encrypted) character file and decrypt it, then write the decrypted information to a temporary xml file
        FileStream decrypted_file = new FileStream(input_file, FileMode.Open);
        FileStream temp_file = new FileStream(output_file, FileMode.Create);
        CryptoStream cryptography_stream = new CryptoStream(decrypted_file, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
        using (MemoryStream msDecrypt = new MemoryStream())
        {
            using (BufferedStream readBuffer = new BufferedStream(cryptography_stream))
            using (StreamReader srDecrypt = new StreamReader(readBuffer))
            {
                using (BufferedStream writeBuffer = new BufferedStream(temp_file))
                using (StreamWriter swTemp = new StreamWriter(writeBuffer))
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
        tagName = "charactername" + position;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            characterInfo = item + " -";
        }
        elemList.Clear();

        tagName = "characterlevel" + position;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            characterInfo = characterInfo + " Lv. " + item;
        }
        elemList.Clear();

        tagName = "charactersubrace" + position;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            characterInfo = characterInfo +  " " + item;
        }
        elemList.Clear();

        tagName = "characterrace" + position;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            characterInfo = characterInfo + " " + item;
        }
        elemList.Clear();

        tagName = "characterclass" + position;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
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
