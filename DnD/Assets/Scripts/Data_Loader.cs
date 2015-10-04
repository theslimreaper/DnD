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
		string input_file = filename;
		List<string> keyList = new List<string>();
		UnicodeEncoding encoding = new UnicodeEncoding ();
		byte[] key = null;
		RijndaelManaged RMCrypto = new RijndaelManaged ();
		int data;
		
		
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();
		keyList = XML.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Key/encryptionKey.xml", "key");
		foreach (var item in keyList) {
			keyvalue = item;
		}
		key = encoding.GetBytes (keyvalue);
		
		FileStream decrypted_file = new FileStream (input_file, FileMode.Open);
		CryptoStream cryptography_stream = new CryptoStream (decrypted_file, RMCrypto.CreateDecryptor (key, key), CryptoStreamMode.Read);
		using (MemoryStream msDecrypt = new MemoryStream()) {
			using (StreamReader swDecrypt = new StreamReader(cryptography_stream)) {
				Debug.Log (swDecrypt.ReadToEnd());
			}
		}


		cryptography_stream.Close ();
		decrypted_file.Close ();
		
	}
	
	
}
