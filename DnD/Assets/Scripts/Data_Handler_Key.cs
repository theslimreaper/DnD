using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;


//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!DO NOT ADD ANYTHING TO THIS SCRIPT OTHER THAN CODE TO RETRIEVE THE ENCRYPTION/DECRYPTION KEY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
public class Data_Handler_Key : MonoBehaviour {
    public static string keyvalue = "";
	// Use this for initialization
	void Start () {
        getKey();
	}

    void getKey()
    {
        List<string> keyList = new List<string>();

        //Get encryption / decryption key from url
        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();
        keyList = XML.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Key/encryptionKey.xml", "key");
        foreach (var item in keyList)
        {
            keyvalue = item;
        }
    }
}
