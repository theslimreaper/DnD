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
	public void LoadData(string filename)
	{
		string keyvalue = "";
		string line = "";
		string input_file = filename;
		string output_file = "temp.xml";
		List<string> keyList = new List<string>();
		List<string> charClass = new List<string> ();
		List<string> charRace = new List<string> ();
		List<string> charSubrace = new List<string> ();
		UnicodeEncoding encoding = new UnicodeEncoding ();
		byte[] key = null;
		RijndaelManaged RMCrypto = new RijndaelManaged ();
		
		
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		keyList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Key/encryptionKey.xml", "key");
		foreach (var item in keyList) {
			keyvalue = item;
		}
		key = encoding.GetBytes (keyvalue);
		
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

		charClass = XML.LoadInnerXmlFromFile (output_file, "characterclass");
		charRace = XML.LoadInnerXmlFromFile (output_file, "characterrace");
		charSubrace = XML.LoadInnerXmlFromFile (output_file, "charactersubrace");

		foreach(var item in charClass){
			Character_Info.characterClass = item;
		}
		foreach(var item in charRace){
			Character_Info.characterRace = item;
		}
		foreach(var item in charSubrace){
			Character_Info.characterSubrace = item;
		}

		File.Delete (output_file);

	}
}
