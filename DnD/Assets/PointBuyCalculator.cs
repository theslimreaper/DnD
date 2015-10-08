using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointBuyTracker : MonoBehaviour {
    public static int PointBuyTotal = 27;
    public static int oldTotal = 27;
    public static int PointBuyLeft = 27;
    public InputField TotalPointsInput;
    public Text pointBuyRemaining;
    //public Dropdown baseInput;
    public InputField RaceInput;
    public InputField FinalScore;
    public InputField Modifier;
    public Text ProblemText;
    public static int[] PointCostPerStat= new int[6];
    public int AbilityNumber;
    public void onBaseUpdate(string newValue)
    {
      /*  print("Updated base");
       
        if (baseInput.value+8 <= 13)//calculate points used by choice
        {
            print("8 (0) to 13 (4) used");
            PointCostPerStat[AbilityNumber - 1] = baseInput.value;
        }
        else if (baseInput.value + 8 <= 15)
        {
            print("14 (5) or 15 (6) used");
            PointCostPerStat[AbilityNumber - 1] = 5+(baseInput.value - 5) * 2;
        }
        else if (baseInput.value + 8 <= 17)
        {
            print("16 (7) or 17 (8) used");
            PointCostPerStat[AbilityNumber - 1] = 9+(baseInput.value- 7) * 3;
        }
        else
        {
            PointCostPerStat[AbilityNumber - 1] = 19;
        }


        //look at each stat and find remaining points
        PointBuyLeft = PointBuyTotal;
        for (int i=0;i<6;i++)
        {
            PointBuyLeft -= PointCostPerStat[i];
        }
        pointBuyRemaining.text = "You have " + PointBuyLeft + " points left to spend.";

        //update results inputfield
        FinalScore.text = (System.Convert.ToInt32(RaceInput.text) + baseInput.value + 8).ToString();
        if (System.Convert.ToInt32(FinalScore.text) >= 10)
        {
            Modifier.text = (((System.Convert.ToInt32(RaceInput.text) + baseInput.value + 8) - 10) / 2).ToString();
        }
        else
        {
            Modifier.text= (((System.Convert.ToInt32(RaceInput.text) + baseInput.value + 8) - 11) / 2).ToString();
        }
*/
        
    }
    public void onRacialUpdate(string newValue)
    {
        /*print("Updated racial");
        if (System.Convert.ToInt32(RaceInput.text) <0 && RaceInput.text[0]!='-')
        {
            RaceInput.text = "-" + RaceInput.text;
        }
        if (System.Convert.ToInt32(RaceInput.text) >= 0 && RaceInput.text[0] != '+')
        {
            RaceInput.text = "+" + RaceInput.text;
        }


        //update results inputfield
        FinalScore.text = (System.Convert.ToInt32(RaceInput.text) + baseInput.value + 8).ToString();
        Modifier.text = (((System.Convert.ToInt32(RaceInput.text) + baseInput.value + 8) -10)/2).ToString();*/
    }

    public void updateTotalPoints()
    {
        /*//capture old number
        oldTotal = PointBuyTotal;
        //use new value
        PointBuyTotal = System.Convert.ToInt32(TotalPointsInput.text);
        //correct current points
        PointBuyLeft = PointBuyLeft + (PointBuyTotal - oldTotal);
        pointBuyRemaining.text = "You have " + PointBuyLeft + " points left to spend.";*/
   }

}
