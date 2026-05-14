using UnityEngine;

public class EndGameUI : MonoBehaviour , IUIState
{
    [SerializeField] private GameObject endGameUIObj;

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
