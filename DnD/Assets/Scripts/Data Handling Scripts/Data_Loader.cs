using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Data_Loader : ScriptableObject {
    public List<string> LoadCharacterIDs()
    {
        string line = "";
        string input_file = "./Saved Data/characters.xml";
        string output_file = "temp.xml";
        List<string> keyList = new List<string>();
        List<string> elemList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();
        Image_Converter ImageConverter = ScriptableObject.CreateInstance<Image_Converter>();
        int i = 0;

        elemList.Clear();

        //Get encryption / decryption key from url
        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();
        key = encoding.GetBytes(Data_Handler_Key.keyvalue);
        if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Saved Data")) && (File.Exists((Path.Combine(Directory.GetCurrentDirectory(), "Saved Data/characters.xml")))))
        {
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
            elemList = XML.LoadInnerXmlFromFile(output_file, "id");
            foreach (var item in elemList)
            {
                if (i < Convert.ToInt32(item))
                    i = Convert.ToInt32(item);
            }

            //Delete the temporary xml file
            File.Delete(output_file);
        }
        Character_Info.maxid = i + 1;
        return elemList;
    }
	public void LoadCharacterData(int id)
	{
		string line = "";
		string input_file = "./Saved Data/characters.xml";
		string output_file = "temp.xml";
		List<string> keyList = new List<string>();
		List<string> elemList = new List<string> ();
		UnicodeEncoding encoding = new UnicodeEncoding ();
		byte[] key = null;
		RijndaelManaged RMCrypto = new RijndaelManaged ();
        Image_Converter ImageConverter = ScriptableObject.CreateInstance<Image_Converter>();
        string tagName = "";
		
		//Get encryption / decryption key from url
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		key = encoding.GetBytes (Data_Handler_Key.keyvalue);

		//Open / read the selected (encrypted) character file and decrypt it, then write the decrypted information to a temporary xml file
		FileStream decrypted_file = new FileStream (input_file, FileMode.Open);
		FileStream temp_file = new FileStream(output_file, FileMode.Create);
		CryptoStream cryptography_stream = new CryptoStream (decrypted_file, RMCrypto.CreateDecryptor (key, key), CryptoStreamMode.Read);
		using (MemoryStream msDecrypt = new MemoryStream()) {
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
		cryptography_stream.Close ();
		decrypted_file.Close ();

		//Call functions to load data from temporary xml file into specified game objects

        //Get character overview info
        tagName = "avatar" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        Character_Info.characterAvatar = ImageConverter.ConvertStringToImage(elemList[0]);
        elemList.Clear();

        tagName = "charactername" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		Character_Info.characterName = elemList[0];
		elemList.Clear ();

        tagName = "characterclass" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		Character_Info.characterClass = elemList[0];
		elemList.Clear ();

        tagName = "characterrace" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        Character_Info.characterRace = elemList[0];
		elemList.Clear ();

        tagName = "charactersubrace" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
	    Character_Info.characterSubrace = elemList[0];
		elemList.Clear ();

        tagName = "alignment" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
	    Character_Info.characterAlignment = elemList[0];
		elemList.Clear ();

		tagName = "age" + id;
		elemList = XML.LoadInnerXmlFromFile (output_file, tagName);
	    Character_Info.characterAge = elemList[0];
        elemList.Clear();

        tagName = "gender" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
	    Character_Info.characterGender = elemList[0];
		elemList.Clear ();

        tagName = "characterlevel" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        Character_Info.characterLevel = elemList[0];
        elemList.Clear();

        tagName = "health" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        Character_Info.characterHealth = elemList[0];
		elemList.Clear ();

        tagName = "height" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		Character_Info.characterHeight = elemList[0];
		elemList.Clear ();

        tagName = "weight" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		Character_Info.characterWeight = elemList[0];
		elemList.Clear ();

        tagName = "carryweight" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        Character_Info.characterCarryWeight = elemList[0];
		elemList.Clear ();

        tagName = "movespeed" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		Character_Info.characterMoveSpeed = elemList[0];
		elemList.Clear ();

        tagName = "languages" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		Character_Info.characterLanguages = elemList[0];
		elemList.Clear ();

        //Get notes related to the character
		Note_List_Info.noteTitles.Clear ();
        tagName = "title" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		foreach(var item in elemList){
			Note_List_Info.noteTitles.Add (item);
		}
		elemList.Clear ();

		Note_List_Info.noteDates.Clear ();
        tagName = "date" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
		foreach(var item in elemList){
			Note_List_Info.noteDates.Add (item);
		}
		elemList.Clear ();

		Note_List_Info.noteSubjects.Clear ();
        tagName = "subject" + id;
		elemList = XML.LoadInnerXmlFromFile (output_file, tagName);
		foreach(var item in elemList){
			Note_List_Info.noteSubjects.Add(item);
		}
		elemList.Clear ();

        //Get the character's coin
        Character_Info.copper = 0;
        tagName = "copper" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            Character_Info.copper = Convert.ToInt32(item);
        }
        elemList.Clear();

        Character_Info.silver = 0;
        tagName = "silver" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            Character_Info.silver = Convert.ToInt32(item);
        }
        elemList.Clear();

        Character_Info.electrum = 0;
        tagName = "electrum" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            Character_Info.electrum = Convert.ToInt32(item);
        }
        elemList.Clear();

        Character_Info.gold = 0;
        tagName = "gold" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            Character_Info.gold = Convert.ToInt32(item);
        }
        elemList.Clear();

        Character_Info.platinum = 0;
        tagName = "platinum" + id;
        elemList = XML.LoadInnerXmlFromFile(output_file, tagName);
        foreach (var item in elemList)
        {
            Character_Info.platinum = Convert.ToInt32(item);
        }
        elemList.Clear();

        Character_Info.id = id;

		//Delete the temporary xml file
		File.Delete (output_file);

	}

    public void LoadSettingsData()
    {
        string line = "";
        string input_file = "./Saved Data/settings.xml";
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
        if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Saved Data")) && (File.Exists((Path.Combine(Directory.GetCurrentDirectory(), "Saved Data/settings.xml")))))
        {
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
            elemList = XML.LoadInnerXmlFromFile(output_file, "mode");
            foreach (var item in elemList)
            {
                switch (item)
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

            elemList = XML.LoadInnerXmlFromFile(output_file, "bgmusicvol");
            foreach (var item in elemList)
            {
                Settings_Screen.BGMusicVol = float.Parse(item);
            }
            elemList.Clear();

            elemList = XML.LoadInnerXmlFromFile(output_file, "sfxvol");
            foreach (var item in elemList)
            {
                Settings_Screen.SFXVol = float.Parse(item);
            }
            elemList.Clear();

            //Delete the temporary xml file
            File.Delete(output_file);
        }
    }
}
