using UnityEngine;
using System.Collections;
using System.Xml;
using System.Net;


public class XML_Loader : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		LoadXml ();
	}

	//Loads specified XML file content
	public void LoadXml () {
		var m_strFilePath = "https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Spells/spells.xml";
		string xmlStr;
		var xmlDoc = new XmlDocument();

		//Get SSL Certificate Validated
		System.Net.ServicePointManager.ServerCertificateValidationCallback += (s,ce,ca,p) => true;

		//Get file from URL
		using(var wc = new WebClient())
		{
			xmlStr = wc.DownloadString(m_strFilePath);
		}

		//Load content of file
		xmlDoc.LoadXml(xmlStr);    
		print (xmlStr);
	}
	
}
