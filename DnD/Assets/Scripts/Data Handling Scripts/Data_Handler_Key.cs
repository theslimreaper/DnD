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
    public GameObject key_text;
	// Use this for initialization
	void Start () {
	}

    void Awake()
    {
        getKey();
    }

	//Grab the encryption / decryption key from the specified url
    void getKey()
    {
        keyvalue = gameObject.GetComponent<Text>().text;
    }
}
