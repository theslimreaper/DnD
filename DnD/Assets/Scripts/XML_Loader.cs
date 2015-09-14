using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Net;

public class XML_Loader : ScriptableObject {

	public List<string> LoadXml(string url, string tagName) {
		XmlNodeList elemList = null;
		var doc = new XmlDocument();
		List<string> strList = new List<string>();

		doc = GetXmlContent (url);

		elemList = GetXmlElems (doc, tagName);

		strList = ConvertElemsToList (elemList);

		return strList;
	}
	//Loads specified XML file content
	XmlDocument GetXmlContent (string url) {
		var m_strFilePath = url;
		string xmlStr;
		var doc = new XmlDocument();
		
		//Get SSL Certificate Validated
		System.Net.ServicePointManager.ServerCertificateValidationCallback += (s,ce,ca,p) => true;
		
		//Get file from URL
		using(var wc = new WebClient())
		{
			xmlStr = wc.DownloadString(m_strFilePath);
		}
		
		//Load content of file
		doc.LoadXml(xmlStr);   
		
		return doc;
	}

	//Get elements of XML file based on groups of a tag name
	XmlNodeList GetXmlElems (XmlDocument doc, string tagName) {
		//Organize sections of file (spells, classes, etc.) into lists based on tag
		XmlNodeList elemList = doc.GetElementsByTagName(tagName);

		return elemList;
	}

	//Convert the element list into a string list
	List<string> ConvertElemsToList (XmlNodeList elemList) {
		List<string> strList = new List<string>();

		for (int i=0; i < elemList.Count; i++)
		{   
			strList.Add(elemList[i].OuterXml);
		}  

		return strList;
	}
	
}
