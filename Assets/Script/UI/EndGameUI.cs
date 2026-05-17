using UnityEngine;
using TMPro;

public class EndGameUI : MonoBehaviour , IUIState
{
    [SerializeField] private GameObject endGameUIObj;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text coin;
    [SerializeField] private TMP_Text damage;

    public void OpenUI(float timeToClear,int totalCoinEarn,int totalDamage)
    {
        Debug.Log(timeToClear + "timeToClear");
        Debug.Log(totalCoinEarn + "totalCoinEarn");
        Debug.Log(totalDamage + "totalDamage");

        damage.text = "Total Damage : " + totalDamage;
        coin.text = "Coin Earn : " + totalCoinEarn;
        time.text = "Time To Complete : " + timeToClear + " Sec";
    }

    public void Enter()
    {
        Debug.Log("Enable");
        endGameUIObj.SetActive(true);
    }

    public void Exit()
    {
        endGameUIObj.SetActive(false);
    }
}
