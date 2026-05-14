using UnityEngine;

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
}
