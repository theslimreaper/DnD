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

	
    public void DeleteFile( string filename )
    {
        string character_directory = "Saved Characters";
        string currentPath = Directory.GetCurrentDirectory();
        string delete_file = filename + ".xml";
        character_directory = Path.Combine(currentPath, character_directory);
        delete_file = Path.Combine(character_directory, delete_file);

        File.Delete(delete_file);
    }
}
