using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrainedSkillChecker : MonoBehaviour {
    public int skillNumber;
    public InputField extraModifier;
    public Text checkResults;
    public int lastResult;
    public GameObject ResultBG;
    public GameObject SkillResultsText;
    public void onclickRoll()
    {
        lastResult = 0;
        lastResult += Skill_Handler.values[skillNumber-1];
        if(extraModifier.text!=null&& extraModifier.text!="")
        {
            lastResult += System.Convert.ToInt32(extraModifier.text);
        }

        lastResult += Random.Range(1, 21);
        ResultBG.SetActive(true);
        SkillResultsText.GetComponent<Text>().text = "You Rolled: " + lastResult + "\nfor " + Skill_Handler.skillNames[skillNumber-1];

    }

    public void onclickHideResults()
    {
        GameObject.Find("Roll Result BG").SetActive(false);
    }

}
