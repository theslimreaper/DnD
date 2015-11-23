using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;

public class Background_Music : MonoBehaviour {
    public AudioClip soundClip;
    public AudioSource audioSource;
    private static Background_Music instance = null;
    public static Background_Music Instance
    {
        get { return instance; }
    }
    void Awake() {
     if (instance != null && instance != this) {
         Destroy(this.gameObject);
         return;
     } else {
         instance = this;
     }
     DontDestroyOnLoad(this.gameObject);
 }


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = Settings_Screen.BGMusicVol;
        audioSource.clip = soundClip;
        audioSource.Play();
    }

    public void VolumeChange(Slider slider)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Settings_Screen.BGMusicVol = slider.value;
        audioSource.volume = slider.value;
    }

    public void SoundChanger(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
