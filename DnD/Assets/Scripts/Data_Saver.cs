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
	public void SaveData(string filename)
	{
		string output_file = filename + ".xml";
        string character_directory = "Saved Characters";
		string keyvalue = "";
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

		//Get encryption / decryption key from url
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		keyList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Key/encryptionKey.xml", "key");
		foreach (var item in keyList) {
			keyvalue = item;
		}
		key = encoding.GetBytes (keyvalue);

		//Collect data to be saved and write it to an encrypted xml file using the key retrieved earlier
		FileStream encrypted_file = new FileStream (output_file, FileMode.Create);
		CryptoStream cryptography_stream = new CryptoStream (encrypted_file, RMCrypto.CreateEncryptor (key, key), CryptoStreamMode.Write);
		using (MemoryStream msEncrypt = new MemoryStream()) {
			using (StreamWriter swEncrypt = new StreamWriter(cryptography_stream)) {
				contentList = CollectData ();
				foreach( var content in contentList ){
				swEncrypt.WriteLine (content);
					Debug.Log (content);
				}
			}
		}

		cryptography_stream.Close ();
		encrypted_file.Close ();
	}

	//Format data into xml format
	List<string> CollectData (){
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

		content = "</characterinfo>";
		contentList.Add (content);

		content = "</savedcharacter>";
		contentList.Add (content);

		return contentList;
	}
	
	
}
