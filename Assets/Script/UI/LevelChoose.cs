using UnityEngine;

public class LevelChoose : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SceneManager sceneManager;

    private void Start()
    {
        playerData = GameManager.Instance.PlayerData;
        sceneManager = GameManager.Instance.SceneManager;
    }
    public void ChooseLevel(int level)
    {
        if (playerData.GetLevel(level))
        {
            sceneManager.LevelLoadScene(level);
        }
    }
}
