using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Data_Deleter : ScriptableObject {

	
    public void DeleteFile()
    {
        string output_file = "characters.xml";
        string character_directory = "Saved Data";
        List<string> keyList = new List<string>();
        List<string> contentList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();
        string currentPath = Directory.GetCurrentDirectory();
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver>();
        List<string> tempList = new List<string>();

            contentList = Save.GetAllData();

        character_directory = Path.Combine(currentPath, character_directory);
        output_file = Path.Combine(character_directory, output_file);

        //Get key in byte form
        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);

        //Collect data to be saved and write it to an encrypted xml file using the key retrieved earlier
        FileStream encrypted_file = new FileStream(output_file, FileMode.Create);
        CryptoStream cryptography_stream = new CryptoStream(encrypted_file, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (StreamWriter swEncrypt = new StreamWriter(cryptography_stream))
            {
                swEncrypt.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                swEncrypt.WriteLine("<savedcharacters>");
                    foreach (var content in contentList)
                    {
                        swEncrypt.WriteLine(content);
                    }
                contentList.Clear();
                swEncrypt.WriteLine("</savedcharacters>");
            }
        }

        cryptography_stream.Close();
        encrypted_file.Close();

        tempList = Load.LoadCharacterIDs();
    }
}
