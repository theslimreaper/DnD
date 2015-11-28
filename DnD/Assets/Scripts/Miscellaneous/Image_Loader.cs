using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;
using System.Diagnostics;

public class Image_Loader : MonoBehaviour {
    public GameObject avatarImage;
    public GameObject url;
    public GameObject filename;
    public GameObject uploadBox;
    public CanvasGroup uploadCanvasGroup;
    public Message_Handler MessageBoxOK;

    // Use this for initialization
    void Start () {
        Character_Info.characterAvatar = avatarImage.GetComponent<Image>().sprite;
        filename.GetComponent<InputField>().interactable = false;
        HideBox();
	}

    public void openDialog()
    {

        var path = EditorUtility.OpenFilePanel(
                "",
                "",
                ";*.png;*jpg");

        if( path.Length != 0)
        {
            filename.GetComponent<InputField>().text = path;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UploadImageFromFile()
    {
        LoadImageFromFile(filename.GetComponent<InputField>().text);
        avatarImage.GetComponentInChildren<Text>().text = "";
    }

    public void LoadImageFromFile(string image)
    {
        string pathPrefix = @"file://";

        CheckImage(image);

        if (image.EndsWith("jpg") || image.EndsWith("png"))
        {
            Texture2D avatar = new Texture2D(1, 1, TextureFormat.Alpha8, false);
            string fullFilename = pathPrefix + image;
            WWW www = new WWW(fullFilename);
            //LoadImageIntoTexture compresses JPGs by DXT1 and PNGs by DXT5     
            www.LoadImageIntoTexture(avatar);
            Rect tempRect = new Rect(0, 0, avatar.width, avatar.height);
            Sprite tempSprite = Sprite.Create(avatar, tempRect, new Vector2(0.5f, 0.5f));
            avatarImage.GetComponent<Image>().sprite = tempSprite;
            HideBox();
        }
    }

    public void LoadImage()
    {
        CheckImage(url.GetComponent<InputField>().text);
        if (url.GetComponent<InputField>().text.EndsWith("jpg") || url.GetComponent<InputField>().text.EndsWith("png"))
        {
            StartCoroutine(DownloadImage(url.GetComponent<InputField>().text));
            avatarImage.GetComponentInChildren<Text>().text = "";
            HideBox();
        }
    }

    void CheckImage(string image)
    {
        if(!image.EndsWith("jpg") && !image.EndsWith("png"))
        {
            MessageBoxOK.ShowBox("Please select a valid file type (.jpg or .png)!");
        }
    }

    IEnumerator<Sprite> DownloadImage(string image)
    {
        string pathPrefix = @"";
        Texture2D avatar = new Texture2D(1, 1, TextureFormat.Alpha8, false);
        string fullFilename = pathPrefix + image;
        WWW www = new WWW(fullFilename);
        while( !www.isDone )
        {
        }
        //LoadImageIntoTexture compresses JPGs by DXT1 and PNGs by DXT5     
        www.LoadImageIntoTexture(avatar);
        Rect tempRect = new Rect(0, 0, avatar.width, avatar.height);
        Sprite tempSprite = Sprite.Create(avatar, tempRect, new Vector2(0.5f, 0.5f));
        avatarImage.GetComponent<Image>().sprite = tempSprite;
        yield return tempSprite;
    }

    public void HideBox()
    {
        url.GetComponent<InputField>().text = "";
        filename.GetComponent<InputField>().text = "";
        uploadCanvasGroup.alpha = 0;
        uploadCanvasGroup.interactable = false;
        uploadBox.SetActive(false);
    }

    public void ShowBox()
    {
        uploadCanvasGroup.alpha = 1;
        uploadCanvasGroup.interactable = true;
        uploadBox.SetActive(true);
    }
}
