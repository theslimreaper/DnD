using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

public class Image_Converter : ScriptableObject
{
    public string ConvertImageToString(Sprite sprite){
        string base64 = "";

            byte[] bytes;
            bytes = sprite.texture.EncodeToJPG();

            base64 = Convert.ToBase64String(bytes);
     return base64;
    }
	
    public Sprite ConvertStringToImage(string base64)
    {
        Sprite sprite;
        Texture2D texture;
        byte[] b64_bytes = Convert.FromBase64String(base64);
        texture = new Texture2D(1, 1, TextureFormat.Alpha8, false);
        texture.LoadImage(b64_bytes);
        Rect tempRect = new Rect(0, 0, texture.width, texture.height);
        sprite = Sprite.Create(texture, tempRect, new Vector2(0.5f, 0.5f));
        return sprite;
    }
}
