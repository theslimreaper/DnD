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
        if (clip != null)
        {
            float[] fBytes = new float[clip.samples * clip.channels];
            byte[] bytes;
            float fByte = 0;
            clip.GetData(fBytes, 0);
            for (int s = 0; s < 100; s++) Debug.Log(fBytes[s]);
            string byteStr = fBytes[0].ToString();
            Debug.Log(byteStr);

            fByte = Convert.ToSingle(byteStr);

            bytes = BitConverter.GetBytes(fByte);

            base64 = Convert.ToBase64String(bytes);
        }
         return base64;
    }
	
    public AudioClip ConvertStringToSound(string base64)
    {
        AudioClip clip = Background_Music.Instance.audioSource.clip;
        if (base64 != "" && base64 != null)
        {
            byte[] b64_bytes = System.Convert.FromBase64String(base64);
            float[] fBytes = new float[b64_bytes.Length / sizeof(float)];
            int index = 0;

            for (int i = 0; i < fBytes.Length; i++)
            {
                fBytes[i] = BitConverter.ToSingle(b64_bytes, index);
                index += sizeof(float);
            }

            clip.SetData(fBytes, 0);
        }
        return clip;
    }
}
