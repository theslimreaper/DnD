using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;

public class Sound_Effects : MonoBehaviour {
    private AudioSource audioSource;
    private static Sound_Effects instance = null;
    public static Sound_Effects Instance
    {
        get { return instance; }
    }
    void Awake() {
/*     if (instance != null && instance != this) {
         Destroy(this.gameObject);
         return;
     } else {
         instance = this;
     }
     DontDestroyOnLoad(this.gameObject);*/
        instance = this;
 }


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = Settings_Screen.SFXVol;
    }

    public void VolumeChange(Slider slider)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Settings_Screen.SFXVol = slider.value;
        audioSource.volume = slider.value;
    }
}
