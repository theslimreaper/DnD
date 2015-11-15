using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Data_Saver : ScriptableObject {
    bool newfile = false;
	//Save character data to an encrypted xml file named after the character
	public void SaveCharacterData()
	{
		string output_file = "characters.xml";
        string character_directory = "Saved Data";
		List<string> keyList = new List<string>();
		List<string> contentList = new List<string> ();
		UnicodeEncoding encoding = new UnicodeEncoding ();
		byte[] key = null;
		RijndaelManaged RMCrypto = new RijndaelManaged ();
        string currentPath = Directory.GetCurrentDirectory();
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        List<string> tempList = new List<string>();

        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), character_directory)) || (!File.Exists((Path.Combine(Directory.GetCurrentDirectory(), Path.Combine(character_directory, output_file))))))
        {
            newfile = true;
            Directory.CreateDirectory(Path.Combine(currentPath, character_directory));
        }
        else
        {
            tempList = Load.LoadCharacterIDs();
            if(!(tempList.Count > 0))
            {
                newfile = true;
            }
            else
            {
                newfile = false;
            }
        }

        if(newfile == false)
        {
            contentList = GetAllData();
        }

        character_directory = Path.Combine(currentPath, character_directory);
        output_file = Path.Combine(character_directory, output_file);

		//Get key in byte form
		XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader> ();

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);

		//Collect data to be saved and write it to an encrypted xml file using the key retrieved earlier
		FileStream encrypted_file = new FileStream (output_file, FileMode.Create);
		CryptoStream cryptography_stream = new CryptoStream (encrypted_file, RMCrypto.CreateEncryptor (key, key), CryptoStreamMode.Write);
		using (MemoryStream msEncrypt = new MemoryStream()) {
            using (BufferedStream writeBuffer = new BufferedStream(cryptography_stream))
			using (StreamWriter swEncrypt = new StreamWriter(writeBuffer)) {
                swEncrypt.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                swEncrypt.WriteLine("<savedcharacters>");
                if (newfile == false)
                {
                    foreach (var content in contentList)
                    {
                        swEncrypt.WriteLine(content);
                    }
                }
                contentList.Clear();
                contentList = CollectCharacterData();
                foreach (var content in contentList)
                {
                    swEncrypt.WriteLine(content);
                }
                swEncrypt.WriteLine("</savedcharacters>");
			}
		}

		cryptography_stream.Close ();
		encrypted_file.Close ();

        tempList = Load.LoadCharacterIDs();
	}

	//Format data into xml format
	List<string> CollectCharacterData (){
		List<string> contentList = new List<string> ();
		string content = "";
        Image_Converter ImageConverter = ScriptableObject.CreateInstance<Image_Converter>();

        content = "<id>" + Character_Info.id + "</id>";
        contentList.Add(content);
		content = "<characterinfo>";
		contentList.Add (content);

        content = ImageConverter.ConvertImageToString(Character_Info.characterAvatar);

        content = "<avatar" + Character_Info.id + ">" + content + "</avatar" + Character_Info.id + ">";
        contentList.Add(content);

        content = "<charactername" + Character_Info.id + ">" + Character_Info.characterName + "</charactername" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<characterclass" + Character_Info.id + ">" + Character_Info.characterClass + "</characterclass" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<characterrace" + Character_Info.id + ">" + Character_Info.characterRace + "</characterrace" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<charactersubrace" + Character_Info.id + ">" + Character_Info.characterSubrace + "</charactersubrace" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<alignment" + Character_Info.id + ">" + Character_Info.characterAlignment + "</alignment" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<age" + Character_Info.id + ">" + Character_Info.characterAge + "</age" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<gender" + Character_Info.id + ">" + Character_Info.characterGender + "</gender" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<characterlevel" + Character_Info.id + ">" + Character_Info.characterLevel + "</characterlevel" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<health" + Character_Info.id + ">" + Character_Info.characterHealth + "</health" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<height" + Character_Info.id + ">" + Character_Info.characterHeight + "</height" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<weight" + Character_Info.id + ">" + Character_Info.characterWeight + "</weight" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<carryweight" + Character_Info.id + ">" + Character_Info.characterCarryWeight + "</carryweight" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<movespeed" + Character_Info.id + ">" + Character_Info.characterMoveSpeed + "</movespeed" + Character_Info.id + ">";
		contentList.Add (content);
        content = "<languages" + Character_Info.id + ">" + Character_Info.characterLanguages + "</languages" + Character_Info.id + ">";
		contentList.Add (content);

		content = "<notes>";
		contentList.Add (content);
		int i = 0;
		foreach (var item in Note_List_Info.noteTitles) {
            content = "<title" + Character_Info.id + ">" + Note_List_Info.noteTitles[i] + "</title" + Character_Info.id + ">";
			contentList.Add (content);
            content = "<date" + Character_Info.id + ">" + Note_List_Info.noteDates[i] + "</date" + Character_Info.id + ">";
			contentList.Add (content);
            content = "<subject" + Character_Info.id + ">" + Note_List_Info.noteSubjects[i] + "</subject" + Character_Info.id + ">";
			contentList.Add (content);
			i++;
		}
		content = "</notes>";
		contentList.Add (content);

        content = "<inventory>";
        contentList.Add(content);

        content = "<coinage>";
        contentList.Add(content);
        content = "<copper" + Character_Info.id + ">" + Character_Info.copper + "</copper" + Character_Info.id + ">";
        contentList.Add(content);
        content = "<silver" + Character_Info.id + ">" + Character_Info.silver + "</silver" + Character_Info.id + ">";
        contentList.Add(content);
        content = "<electrum" + Character_Info.id + ">" + Character_Info.electrum + "</electrum" + Character_Info.id + ">";
        contentList.Add(content);
        content = "<gold" + Character_Info.id + ">" + Character_Info.gold + "</gold" + Character_Info.id + ">";
        contentList.Add(content);
        content = "<platinum" + Character_Info.id + ">" + Character_Info.platinum + "</platinum" + Character_Info.id + ">";
        contentList.Add(content);
        content = "</coinage>";
        contentList.Add(content);

        content = "<items>";
        contentList.Add(content);
        foreach(var item in Character_Info.characterItems)
        {
            content = "<itemName" + Character_Info.id + ">" + item.itemName + "</itemName" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemCat" + Character_Info.id + ">" + item.itemCategory + "</itemCat" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemDescr" + Character_Info.id + ">" + item.itemDescr + "</itemDescr" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemWeight" + Character_Info.id + ">" + item.itemWeight + "</itemWeight" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemCost" + Character_Info.id + ">" + item.itemCost + "</itemCost" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemPPO" + Character_Info.id + ">" + item.itemPPO + "</itemPPO" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemProperties" + Character_Info.id + ">" + item.itemProperties + "</itemProperties" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemArmorAC" + Character_Info.id + ">" + item.armorAC + "</itemArmorAC" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemArmorDexPen" + Character_Info.id + ">" + item.armorDexPenalty + "</itemArmorDexPen" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemArmorType" + Character_Info.id + ">" + item.armorType + "</itemArmorType" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemOilType" + Character_Info.id + ">" + item.oilType + "</itemOilType" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemPotionType" + Character_Info.id + ">" + item.potionType+ "</itemPotionType" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemPoisonType" + Character_Info.id + ">" + item.poisonType + "</itemPoisonType" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemPoisonOnset" + Character_Info.id + ">" + item.poisonOnset + "</itemPoisonOnset" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemPoisonFreq" + Character_Info.id + ">" + item.poisonFrequency + "</itemPoisonFreq" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemPPOFortDC" + Character_Info.id + ">" + item.PPOFortDC + "</itemPPOFortDC" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemWpnDmg" + Character_Info.id + ">" + item.wpnDmg + "</itemWpnDmg" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemWpnCrit" + Character_Info.id + ">" + item.wpnCritRange + "</itemWpnCrit" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemWpnType" + Character_Info.id + ">" + item.wpnType + "</itemWpnType" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemVehicleMaxSpeed" + Character_Info.id + ">" + item.vehicleMaxSpeed + "</itemVehicleMaxSpeed" + Character_Info.id + ">";
            contentList.Add(content);
            content = "<itemVehiclePassengers" + Character_Info.id + ">" + item.vehiclePassengers + "</itemVehiclePassengers" + Character_Info.id + ">";
            contentList.Add(content);
        }
        content = "</items>";
        contentList.Add(content);

        content = "</inventory>";
        contentList.Add(content);

        content = "</characterinfo>";
        contentList.Add(content);

        content = "<idend>" + Character_Info.id + "</idend>";
        contentList.Add(content);

		return contentList;
	}
	
	public void SaveSettingsData()
    {
        string output_file = "settings.xml";
        string settings_directory = "Saved Data";
        List<string> keyList = new List<string>();
        List<string> contentList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();
        string currentPath = Directory.GetCurrentDirectory();

        if (!Directory.Exists(Path.Combine(currentPath, settings_directory)))
            Directory.CreateDirectory(Path.Combine(currentPath, settings_directory));

        settings_directory = Path.Combine(currentPath, settings_directory);
        output_file = Path.Combine(settings_directory, output_file);

        //Get key in byte form
        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);

        //Collect data to be saved and write it to an encrypted xml file using the key retrieved earlier
        FileStream encrypted_file = new FileStream(output_file, FileMode.Create);
        CryptoStream cryptography_stream = new CryptoStream(encrypted_file, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (BufferedStream writeBuffer = new BufferedStream(cryptography_stream))
            using (StreamWriter swEncrypt = new StreamWriter(writeBuffer))
            {
                contentList = CollectSettingsData();
                foreach (var content in contentList)
                {
                    swEncrypt.WriteLine(content);
                }
            }
        }
    }

    List<string> CollectSettingsData()
    {
        List<string> contentList = new List<string>();
        string content = "";

        content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        contentList.Add(content);
        content = "<settings>";
        contentList.Add(content);
        switch(Settings_Screen.is_online)
        {
            case true:
                content = "<mode>" + "true" + "</mode>";
                break;
            case false:
                content = "<mode>" + "false" + "</mode>";
                break;
        }
        contentList.Add(content);
        content = "<bgmusicvol>" + Settings_Screen.BGMusicVol + "</bgmusicvol>";
        contentList.Add(content);
        content = "<sfxvol>" + Settings_Screen.SFXVol + "</sfxvol>";
        contentList.Add(content);
        content = "</settings>";
        contentList.Add(content);

        return contentList;
    }

    public List<string> GetAllData()
    {
        string line = "";
        string input_file = "./Saved Data/characters.xml";
        List<string> keyList = new List<string>();
        List<string> elemList = new List<string>();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] key = null;
        RijndaelManaged RMCrypto = new RijndaelManaged();
        string tagID;
        string tagIDend;
        int indexStart = 0;
        int indexEnd = 0;

        key = encoding.GetBytes(Data_Handler_Key.keyvalue);
        FileStream decrypted_file = new FileStream(input_file, FileMode.Open);
        CryptoStream cryptography_stream = new CryptoStream(decrypted_file, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
        using (MemoryStream msDecrypt = new MemoryStream())
        {
            using (BufferedStream readBuffer = new BufferedStream(cryptography_stream))
            using (StreamReader srDecrypt = new StreamReader(readBuffer))
            {
                    while ((line = srDecrypt.ReadLine()) != null)
                    {
                        elemList.Add(line);
                    }
            }
        }
        cryptography_stream.Close();
        decrypted_file.Close();
        tagID = "<id>" + Character_Info.id + "</id>";
        tagIDend = "<idend>" + Character_Info.id + "</idend>";
        int i = 0;
        foreach(var content in elemList)
        {
            if(content == tagID)
            {
                indexStart = i;
            }

            if(content == tagIDend)
            {
                indexEnd = i;
            }
            i++;
        }
        if (indexStart != indexEnd)
        {
            elemList.RemoveRange(indexStart, indexEnd - indexStart);
        }
        elemList.Remove("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        elemList.Remove("<savedcharacters>");
        elemList.Remove("</savedcharacters>");
        return elemList;
    }
}
