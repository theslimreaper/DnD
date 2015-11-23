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

public class Sound_Converter : ScriptableObject
{
    public string ConvertSoundToString(AudioClip clip){
        string base64 = "";

         float[] fBytes = new float[clip.samples * clip.channels];
         byte[] bytes;
         float fByte = 0;
         clip.GetData(fBytes, 0);
         string byteStr = new string(System.Array.ConvertAll(fBytes, x => (char)x));
         Debug.Log(byteStr);

         fByte = Convert.ToSingle(byteStr);

         bytes = BitConverter.GetBytes(fByte);
          
         base64 = Convert.ToBase64String(bytes);
         return base64;
    }
	
    public AudioClip ConvertStringToSound(string base64)
    {
        AudioClip clip = Background_Music.Instance.audioSource.clip;
        byte[] b64_bytes = System.Convert.FromBase64String(base64);
        float[] fBytes = new float[b64_bytes.Length / sizeof(float)];
        int index = 0;

        for (int i = 0; i < fBytes.Length; i++)
        {
            fBytes[i] = BitConverter.ToSingle(b64_bytes, index);
            index += sizeof(float);
        }

            clip.SetData(fBytes, 0);
        return clip;
    }
}
