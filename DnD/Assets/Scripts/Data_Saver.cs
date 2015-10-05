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
		string keyvalue = "";
		List<string> keyList = new List<string>();
		List<string> contentList = new List<string> ();
		UnicodeEncoding encoding = new UnicodeEncoding ();
		byte[] key = null;
		RijndaelManaged RMCrypto = new RijndaelManaged ();

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
		content = "<charactername>" + Character_Info.characterName + "</charactername>";
		contentList.Add (content);
		content = "<characterclass>" + Character_Info.characterClass + "</characterclass>";
		contentList.Add (content);
		content = "<characterrace>" + Character_Info.characterRace + "</characterrace>";
		contentList.Add (content);
		content = "<charactersubrace>" + Character_Info.characterSubrace + "</charactersubrace>";
		contentList.Add (content);
		content = "</savedcharacter>";
		contentList.Add (content);

		return contentList;
	}
	
	
}
