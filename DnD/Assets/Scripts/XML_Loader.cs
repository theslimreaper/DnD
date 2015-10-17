using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System;
using System.Net;

public class XML_Loader : ScriptableObject {

	//Load XML including tagName node
	public List<string> LoadXml(string url, string tagName) {
		XmlNodeList elemList = null;
		var doc = new XmlDocument();
		List<string> strList = new List<string>();

		doc = GetXmlContent (url);

		elemList = GetXmlElems (doc, tagName);

		strList = ConvertElemsToList (elemList);

		return strList;
	}

	//Load XML excluding tagName node
	public List<string> LoadInnerXml(string url, string tagName) {
		XmlNodeList elemList = null;
		var doc = new XmlDocument();
		List<string> strList = new List<string>();
		
		doc = GetXmlContent (url);
		
		elemList = GetXmlElems (doc, tagName);
		
		strList = ConvertInnerElemsToList (elemList);
		
		return strList;
	}

	//Load XML including tag name node from local file
	public List<string>LoadXmlFromFile( string filename, string tagName ){
		XmlNodeList elemList = null;
		var doc = new XmlDocument ();
		XmlTextReader reader = new XmlTextReader(filename);
		List<string> strList = new List<string>();
		
		doc.Load (reader);
		
		elemList = GetXmlElems (doc, tagName);
		
		strList = ConvertElemsToList (elemList);

		reader.Close ();
		
		return strList;		
	}

	//Load XML excluding tag name node from local file
	public List<string>LoadInnerXmlFromFile( string filename, string tagName ){
		XmlNodeList elemList = null;
		XmlTextReader reader = new XmlTextReader(filename);
		var doc = new XmlDocument ();
		List<string> strList = new List<string>();

		doc.Load (reader);
		
		elemList = GetXmlElems (doc, tagName);
		
		strList = ConvertInnerElemsToList (elemList);

		reader.Close ();
		
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

	//Convert the element list into a string list of outer XML content
	List<string> ConvertElemsToList (XmlNodeList elemList) {
		List<string> strList = new List<string>();

		for (int i=0; i < elemList.Count; i++)
		{   
			strList.Add(elemList[i].OuterXml);
		}  

		return strList;
	}
	//Convert the element list into a string list of inner XML content
	List<string> ConvertInnerElemsToList (XmlNodeList elemList) {
		List<string> strList = new List<string>();
		
		for (int i=0; i < elemList.Count; i++)
		{   
			strList.Add(elemList[i].InnerXml);
		}  
		
		return strList;
	}


}
