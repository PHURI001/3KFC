using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject popUpPrefab;
    [SerializeField] private EndGameUI endGameUI;

    private IUIState currentUIState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
    public void SetPopUptext(Vector3 pos, string text, Color color)
    {
        Vector3 cameraPos = Camera.main.WorldToScreenPoint(pos);
        PopUpText pop = Instantiate(popUpPrefab, cameraPos, Quaternion.identity).GetComponent<PopUpText>();
        pop.SetText(text, color);
        pop.gameObject.transform.parent = transform;
    }
}
