using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Settings_Screen : MonoBehaviour {
	int currentScreen;
	public CanvasGroup screenCanvasGroup;
    public GameObject screen;
    public Button onlineButton;
    public Button offlineButton;
    public static bool is_online;
    public static float BGMusicVol = 1;
    public static float SFXVol = 1;
    public static AudioClip BGMusicClip;
    public Message_Handler MessageBoxYN;
    public Message_Handler MessageBoxOK;
    public Slider BGMusicSlider;
    public Slider SFXSlider;
	// Use this for initialization
	void Start () {
        BGMusicSlider.onValueChanged.AddListener(delegate { Background_Music.Instance.VolumeChange(BGMusicSlider); });
        SFXSlider.onValueChanged.AddListener(delegate { Sound_Effects.Instance.VolumeChange(SFXSlider);  });
        HideSettings();
        LoadSettings();
        defineSettings();
	}

    public void ShowSettings()
    {
        LoadSettings();
        screenCanvasGroup.alpha = 1;
        screenCanvasGroup.interactable = true;
        screen.SetActive(true);
        defineSettings();
    }

    public void HideSettings()
    {
        screenCanvasGroup.alpha = 0;
        screenCanvasGroup.interactable = false;
        screen.SetActive(false);
    }

    public void CancelSettings()
    {
        HideSettings();
        LoadSettings();
        defineSettings();
    }

    public void SaveSettings()
    {
        Data_Saver Save = ScriptableObject.CreateInstance<Data_Saver>();
        Save.SaveSettingsData();
        MessageBoxOK.ShowBox("Save Successful!");
        MessageBoxOK.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => HideSettings());
    }

    public void defineSettings()
    {
        switch (is_online)
        {
            case true:
                onlineButton.interactable = false;
                offlineButton.interactable = true;
                break;
            case false:
                onlineButton.interactable = true;
                offlineButton.interactable = false;
                break;
        }

        BGMusicSlider.value = BGMusicVol;
        SFXSlider.value = SFXVol;
        if (BGMusicClip != null)
        {
            Background_Music.Instance.SoundChanger(BGMusicClip);
        }
        else if (BGMusicClip == null && Background_Music.Instance.audioSource.clip != Background_Music.Instance.soundClip)
        {
            Background_Music.Instance.SoundChanger(Background_Music.Instance.soundClip);
        }
    }

    public void promptModeChange()
    {
        switch(is_online)
        {
            case true:
                MessageBoxYN.ShowBox("By switching to offline mode, the application will now retrieve data from local files instead of the internet. Continue?");
                MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => changeMode());
                break;
            case false:
                MessageBoxYN.ShowBox("By switching to online mode, the application will now retrieve data from the internet instead of local files. Continue?");
                MessageBoxYN.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => changeMode());
                break;
        }
    }

    void changeMode()
    {
        switch(is_online)
        {
            case true:
                is_online = false;
                break;
            case false:
                is_online = true;
                break;
        }
        defineSettings();
    }

    public void LoadSettings()
    {
        Data_Loader Load = ScriptableObject.CreateInstance<Data_Loader>();
        Load.LoadSettingsData();
    }

    
}