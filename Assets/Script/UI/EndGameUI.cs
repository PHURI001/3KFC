using UnityEngine;

public class EndGameUI : MonoBehaviour , IUIState
{
    [SerializeField] private GameObject endGameUIObj;

    public void OpenUI(float timeToClear,int totalCoinEarn,int totalDamage)
    {
        Debug.Log(timeToClear + "timeToClear");
        Debug.Log(totalCoinEarn + "totalCoinEarn");
        Debug.Log(totalDamage + "totalDamage");
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
