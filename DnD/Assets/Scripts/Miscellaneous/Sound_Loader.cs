using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;
using System.Diagnostics;

public class Sound_Loader : MonoBehaviour {
    public GameObject filename;
    public Message_Handler MessageBoxOK;

    // Use this for initialization
    void Start () {
        filename.GetComponent<InputField>().interactable = false;
	}

    public void openDialog()
    {

        var path = EditorUtility.OpenFilePanel(
                "",
                "",
                ";*.ogg;*wav");

        if( path.Length != 0)
        {
            filename.GetComponent<InputField>().text = path;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UploadSoundFromFile()
    {
        LoadsoundFromFile(filename.GetComponent<InputField>().text);
    }

    public void LoadsoundFromFile(string sound)
    {
        string pathPrefix = @"file://";

        CheckSound(sound);

        if (sound.EndsWith("ogg") || sound.EndsWith("wav"))
        {
            string fullFilename = pathPrefix + sound;
            StartCoroutine(DownloadClip(fullFilename));
        }
    }

    void CheckSound(string sound)
    {
        if(!sound.EndsWith("ogg") && !sound.EndsWith("wav"))
        {
            MessageBoxOK.ShowBox("Please select a valid file type (.mp3 or .wav)!");
        }
    }

    IEnumerator<AudioClip> DownloadClip(string path)
    {
        AudioClip clip;
        WWW www = new WWW(path);
        while (!www.isDone)
        {
            yield return null;
        }
        clip = www.audioClip;
        yield return clip;
        Background_Music.Instance.SoundChanger(clip);
        Settings_Screen.BGMusicClip = clip;
    }
}
