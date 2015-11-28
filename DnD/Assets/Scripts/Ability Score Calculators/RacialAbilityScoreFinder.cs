using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class RacialAbilityScoreFinder : MonoBehaviour {
	string xmlRaceName;
	string tagToFind;
	string abilityInfoLine;
	public InputField[] pointbuyRaceInputs= new InputField[6];
	public InputField[] RollingRaceInputs= new InputField[6];
	public Dropdown[] RollingAbilityChosen = new Dropdown[6];
	public Text[] RollingFinalResult = new Text[6];
	void Start () {
		Character_Info.characterSubrace = "Dragonborn";//test value, remove after done testing


		if(Character_Info.characterSubrace==null||Character_Info.characterSubrace=="")//use subrace for race if you use one
		{
			xmlRaceName="<name>"+Character_Info.characterRace;
		}
		else
		{
			xmlRaceName="<name>"+Character_Info.characterSubrace;
		}


		if(xmlRaceName.Contains("("))//if the race has extra info remove it before searching
		{
			xmlRaceName=xmlRaceName.Substring(0,xmlRaceName.IndexOf("(")-1);
		}


		XML_Loader xmlLoader = ScriptableObject.CreateInstance<XML_Loader> ();//load xml
		List<string> XmlResult  = new List<string> ();
		XmlResult = xmlLoader.LoadInnerXml ("https://raw.githubusercontent.com/theslimreaper/DnD/master/XML%20Files/Character%20Features/races.xml","race" );

		foreach(var item in XmlResult)//search through race list to find the race you use
		{	
			if(item.Contains(xmlRaceName))
			{
				abilityInfoLine=item.Substring(item.IndexOf("<ability>"),(item.IndexOf("</ability>")-item.IndexOf("<ability>")));//find the abilitys line for your race
				break;
			}
		}

		if(abilityInfoLine.Contains("Str"))
		{
			AbilityScoreInitial.racialScores[0]= System.Convert.ToInt32(abilityInfoLine.Substring(abilityInfoLine.IndexOf("Str")+4,1));
		}
		else
		{
			AbilityScoreInitial.racialScores[0]=0;
		}

		if(abilityInfoLine.Contains("Dex"))
		{
			AbilityScoreInitial.racialScores[1]= System.Convert.ToInt32(abilityInfoLine.Substring(abilityInfoLine.IndexOf("Dex")+4,1));
		}
		else
		{
			AbilityScoreInitial.racialScores[1]=0;
		}

		if(abilityInfoLine.Contains("Con"))
		{
			AbilityScoreInitial.racialScores[2]= System.Convert.ToInt32(abilityInfoLine.Substring(abilityInfoLine.IndexOf("Con")+4,1));
		}
		else
		{
			AbilityScoreInitial.racialScores[2]=0;
		}

		if(abilityInfoLine.Contains("Int"))
		{
			AbilityScoreInitial.racialScores[3]= System.Convert.ToInt32(abilityInfoLine.Substring(abilityInfoLine.IndexOf("Int")+4,1));
		}
		else
		{
			AbilityScoreInitial.racialScores[3]=0;
		}

		if(abilityInfoLine.Contains("Wis"))
		{
			AbilityScoreInitial.racialScores[4]= System.Convert.ToInt32(abilityInfoLine.Substring(abilityInfoLine.IndexOf("Wis")+4,1));
		}
		else
		{
			AbilityScoreInitial.racialScores[4]=0;
		}

		if(abilityInfoLine.Contains("Cha"))
		{
			AbilityScoreInitial.racialScores[5]=System.Convert.ToInt32(abilityInfoLine.Substring(abilityInfoLine.IndexOf("Cha")+4,1));
		}
		else
		{
			AbilityScoreInitial.racialScores[5]=0;
		}

	}

	public void SetPointBuyRacial()
	{
		for(int i=0;i<6;i++)
		{
			pointbuyRaceInputs[i].text="+"+AbilityScoreInitial.racialScores[i].ToString();
		}
	}
	public void setRollforStatsRacial(int SlotNumber)
	{
		if(RollingAbilityChosen[SlotNumber].value==1)
		{
			RollingRaceInputs[SlotNumber].text="+"+AbilityScoreInitial.racialScores[0].ToString();
			RollingFinalResult[SlotNumber].text=(System.Convert.ToInt32(RollingFinalResult[SlotNumber].text)+AbilityScoreInitial.racialScores[0]).ToString();
		}
		if(RollingAbilityChosen[SlotNumber].value==2)
		{
			RollingRaceInputs[SlotNumber].text="+"+AbilityScoreInitial.racialScores[1].ToString();
			RollingFinalResult[SlotNumber].text=(System.Convert.ToInt32(RollingFinalResult[SlotNumber].text)+AbilityScoreInitial.racialScores[1]).ToString();
		}
		if(RollingAbilityChosen[SlotNumber].value==3)
		{
			RollingRaceInputs[SlotNumber].text="+"+AbilityScoreInitial.racialScores[2].ToString();
			RollingFinalResult[SlotNumber].text=(System.Convert.ToInt32(RollingFinalResult[SlotNumber].text)+AbilityScoreInitial.racialScores[2]).ToString();
		}
		if(RollingAbilityChosen[SlotNumber].value==4)
		{
			RollingRaceInputs[SlotNumber].text="+"+AbilityScoreInitial.racialScores[3].ToString();
			RollingFinalResult[SlotNumber].text=(System.Convert.ToInt32(RollingFinalResult[SlotNumber].text)+AbilityScoreInitial.racialScores[3]).ToString();
		}
		if(RollingAbilityChosen[SlotNumber].value==5)
		{
			RollingRaceInputs[SlotNumber].text="+"+AbilityScoreInitial.racialScores[4].ToString();
			RollingFinalResult[SlotNumber].text=(System.Convert.ToInt32(RollingFinalResult[SlotNumber].text)+AbilityScoreInitial.racialScores[4]).ToString();
		}
		if(RollingAbilityChosen[SlotNumber].value==6)
		{
			RollingRaceInputs[SlotNumber].text="+"+AbilityScoreInitial.racialScores[5].ToString();
			RollingFinalResult[SlotNumber].text=(System.Convert.ToInt32(RollingFinalResult[SlotNumber].text)+AbilityScoreInitial.racialScores[5]).ToString();
		}
	}

	public void rollforStatsContinue()
	{
		bool FilledOut=true;

		for(int i =0;i<6;i++)
		{
			if(RollingAbilityChosen[i].value==0)
			{
				FilledOut=false;
				break;
			}
		}
		if(FilledOut)
		{
			Application.LoadLevel ("Screen Hub");
		}
	}

}
