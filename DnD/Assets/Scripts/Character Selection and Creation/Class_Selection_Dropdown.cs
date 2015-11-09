using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class Class_Selection_Dropdown : MonoBehaviour
{
    public GameObject classDescription;
    public CanvasGroup classDescrCanvasGroup;
    List<string> classDescrList = new List<string>();
    List<string> classNameList = new List<string>();
    public Dropdown classDropdown;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start and Update functions

    void Start()
    {
        GetClasses();
        foreach( var item in classNameList )
        {
            classDropdown.options.Add(new Dropdown.OptionData(item));
        }
        classDropdown.value = 1;
        classDropdown.value = 0;
        SelectClass();
        classDropdown.onValueChanged.AddListener(delegate { audioSource.PlayOneShot(audioClip); });
    }

    void LateUpdate()
    {
    }

    //Additional Functions

    void GetClasses()
    {
        int i = 0;
        XML_Loader XML = ScriptableObject.CreateInstance<XML_Loader>();
        if (Settings_Screen.is_online == true)
        {
            classNameList = XML.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classesOverview.xml", "classname");
        }
        else
        {
            classNameList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/classesOverview.xml", "classname");
        }

        if (Settings_Screen.is_online == true)
        {
            classDescrList = XML.LoadInnerXml("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/classesOverview.xml", "description");
        }
        else
        {
            classDescrList = XML.LoadInnerXmlFromFile("..\\XML Files/Character Features/classesOverview.xml", "description");
        }
    }

    //Choose character class and confirm selections
    public void SelectClass()
    {
        Character_Info.characterClass = classNameList[classDropdown.value];
        FillClassDescription(classDropdown.value);
    }

    //Show the description of the highlighted class
    public void FillClassDescription(int position)
    {
        classDescription.GetComponent<Text>().text = classDescrList[position];
    }

    //Clear the class description
    public void ClearClassDescription()
    {
        classDescription.GetComponent<Text>().text = "";
    }

}