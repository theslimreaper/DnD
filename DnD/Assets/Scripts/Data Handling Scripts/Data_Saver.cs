using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Data_Saver : ScriptableObject {
	//Save character data to an encrypted xml file named after the character
	public void SaveCharacterData(string filename)
	{
		string output_file = filename + ".xml";
        string character_directory = "Saved Characters";
		List<string> keyList = new List<string>();
		List<string> contentList = new List<string> ();
		UnicodeEncoding encoding = new UnicodeEncoding ();
		byte[] key = null;
		RijndaelManaged RMCrypto = new RijndaelManaged ();
        string currentPath = Directory.GetCurrentDirectory();

        if (!Directory.Exists(Path.Combine(currentPath, character_directory)))
            Directory.CreateDirectory(Path.Combine(currentPath, character_directory));

        character_directory = Path.Combine(currentPath, character_directory);
        output_file = Path.Combine(character_directory, output_file);

		//Get key in byte form
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);

		//Collect data to be saved and write it to an encrypted xml file using the key retrieved earlier
		FileStream encrypted_file = new FileStream (output_file, FileMode.Create);
		CryptoStream cryptography_stream = new CryptoStream (encrypted_file, RMCrypto.CreateEncryptor (key, key), CryptoStreamMode.Write);
		using (MemoryStream msEncrypt = new MemoryStream()) {
			using (StreamWriter swEncrypt = new StreamWriter(cryptography_stream)) {
				contentList = CollectCharacterData ();
				foreach( var content in contentList ){
				swEncrypt.WriteLine (content);
				}
			}
		}

		cryptography_stream.Close ();
		encrypted_file.Close ();
	}

	//Format data into xml format
	List<string> CollectCharacterData (){
		List<string> contentList = new List<string> ();
		string content = "";

		content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
		contentList.Add (content);
		content = "<savedcharacter>";
		contentList.Add (content);

		content = "<characterinfo>";
		contentList.Add (content);

		content = "<charactername>" + Character_Info.characterName + "</charactername>";
		contentList.Add (content);
		content = "<characterclass>" + Character_Info.characterClass + "</characterclass>";
		contentList.Add (content);
		content = "<characterrace>" + Character_Info.characterRace + "</characterrace>";
		contentList.Add (content);
		content = "<charactersubrace>" + Character_Info.characterSubrace + "</charactersubrace>";
		contentList.Add (content);
		content = "<alignment>" + Character_Info.characterAlignment + "</alignment>";
		contentList.Add (content);
		content = "<age>" + Character_Info.characterAge + "</age>";
		contentList.Add (content);
		content = "<gender>" + Character_Info.characterGender + "</gender>";
		contentList.Add (content);
		content = "<characterlevel>" + Character_Info.characterLevel + "</characterlevel>";
		contentList.Add (content);
		content = "<health>" + Character_Info.characterHealth + "</health>";
		contentList.Add (content);
		content = "<height>" + Character_Info.characterHeight + "</height>";
		contentList.Add (content);
		content = "<weight>" + Character_Info.characterWeight + "</weight>";
		contentList.Add (content);
		content = "<carryweight>" + Character_Info.characterCarryWeight + "</carryweight>";
		contentList.Add (content);
		content = "<movespeed>" + Character_Info.characterMoveSpeed + "</movespeed>";
		contentList.Add (content);
		content = "<languages>" + Character_Info.characterLanguages + "</languages>";
		contentList.Add (content);

		content = "<notes>";
		contentList.Add (content);
		int i = 0;
		foreach (var item in Note_List_Info.noteTitles) {
			content = "<title>" + Note_List_Info.noteTitles[i] + "</title>";
			contentList.Add (content);
			content = "<date>" + Note_List_Info.noteDates[i] + "</date>";
			contentList.Add (content);
			content = "<subject>" + Note_List_Info.noteSubjects[i] + "</subject>";
			Debug.Log(content);
			contentList.Add (content);
			i++;
		}
		content = "</notes>";
		contentList.Add (content);

		content = "</characterinfo>";
		contentList.Add (content);

		content = "</savedcharacter>";
		contentList.Add (content);

		return contentList;
	}
	
	public void SaveSettingsData()
    {
        string output_file = "settings.xml";
        string settings_directory = "Settings";
        List<string> keyList = new List<string>();
        List<string> contentList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();
        string currentPath = Directory.GetCurrentDirectory();

        if (!Directory.Exists(Path.Combine(currentPath, settings_directory)))
            Directory.CreateDirectory(Path.Combine(currentPath, settings_directory));

        settings_directory = Path.Combine(currentPath, settings_directory);
        output_file = Path.Combine(settings_directory, output_file);

        //Get key in byte form
        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);

        //Collect data to be saved and write it to an encrypted xml file using the key retrieved earlier
        FileStream encrypted_file = new FileStream(output_file, FileMode.Create);
        CryptoStream cryptography_stream = new CryptoStream(encrypted_file, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (StreamWriter swEncrypt = new StreamWriter(cryptography_stream))
            {
                contentList = CollectSettingsData();
                foreach (var content in contentList)
                {
                    swEncrypt.WriteLine(content);
                }
            }
        }
    }

    List<string> CollectSettingsData()
    {
        List<string> contentList = new List<string>();
        string content = "";

        content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        contentList.Add(content);
        content = "<settings>";
        contentList.Add(content);
        switch(Settings_Screen.is_online)
        {
            case true:
                content = "<mode>" + "true" + "</mode>";
                break;
            case false:
                content = "<mode>" + "false" + "</mode>";
                break;
        }
        contentList.Add(content);
        content = "</settings>";
        contentList.Add(content);

        return contentList;
    }
}
