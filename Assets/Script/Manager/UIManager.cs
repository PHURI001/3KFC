using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private EndGameUI endGameUI;

    private IUIState currentUIState;
    public void EnableEndGameUI()
    {
        SwitchUIState(endGameUI);
    }

    public void BackToMainMenu()
    {
        GameManager.Instance.SceneManager.GoToMain();
    }

    public void SwitchUIState(IUIState newState)
    {
        currentUIState?.Exit();
        currentUIState = newState;
        currentUIState?.Enter();
    }

    public void GoToMain()
    {
        GameManager.Instance?.SceneManager.GoToMain();
    }
}
