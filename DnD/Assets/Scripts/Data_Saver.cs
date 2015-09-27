using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;

public class Data_Saver : ScriptableObject {
	public void SaveData(string filename)
	{
		filename = filename + ".xml";
		FileInfo upload_file = new FileInfo ("test");
		FtpWebRequest request = (FtpWebRequest)WebRequest.Create(
								"ftp://127.0.0.1/DnD/SavedCharacters/" + filename );
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
