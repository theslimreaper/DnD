using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Sound_Converter : ScriptableObject
{
    public string ConvertSoundToString(AudioClip clip){
        string base64 = "";
        if (clip != null)
        {
            float[] fBytes = new float[clip.samples * clip.channels];
            byte[] bytes = new byte[fBytes.Length * 4];
            clip.GetData(fBytes, 0);
            Buffer.BlockCopy(fBytes, 0, bytes, 0, bytes.Length);

            base64 = Convert.ToBase64String(bytes);
        }
         return base64;
    }
	
    public AudioClip ConvertStringToSound(string base64)
    {
        AudioClip clip = Background_Music.Instance.audioSource.clip;
        if (base64 != "" && base64 != null)
        {
            byte[] b64_bytes = Convert.FromBase64String(base64);
            float[] fBytes = new float[b64_bytes.Length / 4];

            Buffer.BlockCopy(b64_bytes, 0, fBytes, 0, b64_bytes.Length);

            clip.SetData(fBytes, 0);
        }
        return clip;
    }
}
