using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System;

public class Data_Saver : ScriptableObject {
	public void SaveData(string filename)
	{
		filename = filename + ".xml";
		Uri TempURI = new Uri(Path.Combine("ftp://127.0.0.1/DnD/SavedCharacters/", filename));
		FileInfo upload_file = new FileInfo ("test");
		FtpWebRequest request = (FtpWebRequest)WebRequest.Create( TempURI );
		request.EnableSsl = true;
		request.KeepAlive = true;
		request.UseBinary = true;
		request.Method = WebRequestMethods.Ftp.UploadFile;
		Stream ftpStream = request.GetRequestStream ();

		FileStream file = File.OpenRead ("a");

		int length = 1024;
		byte[] buffer = new byte[length];
		int bytesRead = 0;

		do {
			bytesRead = file.Read (buffer, 0, length);
			ftpStream.Write (buffer, 0, bytesRead);
		} while(bytesRead!=0);

		file.Close ();
		ftpStream.Close ();
	}
}
