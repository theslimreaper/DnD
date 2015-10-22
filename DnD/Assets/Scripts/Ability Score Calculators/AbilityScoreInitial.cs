using UnityEngine;
using System.Collections;

public class AbilityScoreInitial : MonoBehaviour {
    public GameObject RollPage;
    public GameObject pointBuyPage;

    public void onRollforStats()
    {
        pointBuyPage.SetActive(false);
        RollPage.SetActive(true);
    }

    public void onPointBuyCalculator()
    {
        pointBuyPage.SetActive(true);
        RollPage.SetActive(false);
    }
}
