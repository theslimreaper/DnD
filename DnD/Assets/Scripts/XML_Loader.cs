using UnityEngine;
using System.Collections;
using System.Xml;
using System.Net;


public class XML_Loader : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		LoadXml ();
	}
	
	public void LoadXml () {
		var m_strFilePath = "http://www.w3schools.com/xml/note.xml";
		string xmlStr;
		using(var wc = new WebClient())
		{
			xmlStr = wc.DownloadString(m_strFilePath);
		}
		var xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(xmlStr);    
		print (xmlStr);
	}
	
}
