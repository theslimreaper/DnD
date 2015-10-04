﻿using UnityEngine;
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
		
		FileStream encrypted_file = new FileStream (output_file, FileMode.Create);
		CryptoStream cryptography_stream = new CryptoStream (encrypted_file, RMCrypto.CreateEncryptor (key, key), CryptoStreamMode.Write);
		using (MemoryStream msEncrypt = new MemoryStream()) {
			using (StreamWriter swEncrypt = new StreamWriter(cryptography_stream)) {
				swEncrypt.Write ("AND HIS NAME IS JOHN CENA");
			}
		}


		cryptography_stream.Close ();
		encrypted_file.Close ();
		
	}
	
	
}
