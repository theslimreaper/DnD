﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Data_Loader : ScriptableObject {
	public void LoadCharacterData(string filename)
	{
		string line = "";
		string input_file = filename;
		string output_file = "temp.xml";
		List<string> keyList = new List<string>();
		List<string> elemList = new List<string> ();
		UnicodeEncoding encoding = new UnicodeEncoding ();
		byte[] key = null;
		RijndaelManaged RMCrypto = new RijndaelManaged ();
        Image_Converter ImageConverter = ScriptableObject.CreateInstance<Image_Converter>();
		
		//Get encryption / decryption key from url
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		key = encoding.GetBytes (Data_Handler_Key.keyvalue);

		//Open / read the selected (encrypted) character file and decrypt it, then write the decrypted information to a temporary xml file
		FileStream decrypted_file = new FileStream (input_file, FileMode.Open);
		FileStream temp_file = new FileStream(output_file, FileMode.Create);
		CryptoStream cryptography_stream = new CryptoStream (decrypted_file, RMCrypto.CreateDecryptor (key, key), CryptoStreamMode.Read);
		using (MemoryStream msDecrypt = new MemoryStream()) {
			using (StreamReader srDecrypt = new StreamReader(cryptography_stream)){
				using( StreamWriter swTemp = new StreamWriter(temp_file)){
				while((line = srDecrypt.ReadLine ()) != null ){
						swTemp.WriteLine(line);
					}
				}
			}
		}
		cryptography_stream.Close ();
		decrypted_file.Close ();

		//Call functions to load data from temporary xml file into specified game objects
        elemList = XML.LoadInnerXmlFromFile(output_file, "avatar");
        foreach (var item in elemList)
        {
            Character_Info.characterAvatar = ImageConverter.ConvertStringToImage(item);
        }
        elemList.Clear();

		elemList = XML.LoadInnerXmlFromFile (output_file, "charactername");
		foreach(var item in elemList){
			Character_Info.characterName = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "characterclass");
		foreach(var item in elemList){
			Character_Info.characterClass = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "characterrace");
		foreach(var item in elemList){
			Character_Info.characterRace = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "charactersubrace");
		foreach(var item in elemList){
			Character_Info.characterSubrace = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "alignment");
		foreach(var item in elemList){
			Character_Info.characterAlignment = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "age");
		foreach(var item in elemList){
			Character_Info.characterAge = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "gender");
		foreach(var item in elemList){
			Character_Info.characterGender = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "characterlevel");
		foreach(var item in elemList){
			Character_Info.characterLevel = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "health");
		foreach(var item in elemList){
			Character_Info.characterHealth = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "height");
		foreach(var item in elemList){
			Character_Info.characterHeight = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "weight");
		foreach(var item in elemList){
			Character_Info.characterWeight = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "carryweight");
		foreach(var item in elemList){
			Character_Info.characterCarryWeight = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "movespeed");
		foreach(var item in elemList){
			Character_Info.characterMoveSpeed = item;
		}
		elemList.Clear ();

		elemList = XML.LoadInnerXmlFromFile (output_file, "languages");
		foreach(var item in elemList){
			Character_Info.characterLanguages = item;
		}
		elemList.Clear ();

		Note_List_Info.noteTitles.Clear ();
		elemList = XML.LoadInnerXmlFromFile (output_file, "title");
		foreach(var item in elemList){
			Note_List_Info.noteTitles.Add (item);
		}
		elemList.Clear ();

		Note_List_Info.noteDates.Clear ();
		elemList = XML.LoadInnerXmlFromFile (output_file, "date");
		foreach(var item in elemList){
			Note_List_Info.noteDates.Add (item);
		}
		elemList.Clear ();

		Note_List_Info.noteSubjects.Clear ();
		elemList = XML.LoadInnerXmlFromFile (output_file, "subject");
		foreach(var item in elemList){
			Note_List_Info.noteSubjects.Add(item);
		}
		elemList.Clear ();

		//Delete the temporary xml file
		File.Delete (output_file);

	}

    public void LoadSettingsData()
    {
        string line = "";
        string input_file = "./Settings/settings.xml";
        string output_file = "temp.xml";
        List<string> keyList = new List<string>();
        List<string> elemList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();

        //Get encryption / decryption key from url
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
        elemList = XML.LoadInnerXmlFromFile(output_file, "mode");
        foreach (var item in elemList)
        {
            switch(item)
            {
                case "true":
                    Settings_Screen.is_online = true;
                    break;
                case "false":
                    Settings_Screen.is_online = false;
                    break;
            }
        }
        elemList.Clear();

        //Delete the temporary xml file
        File.Delete(output_file);
    }
}
