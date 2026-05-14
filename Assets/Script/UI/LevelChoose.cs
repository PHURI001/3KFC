using UnityEngine;

public class LevelChoose : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SceneManager sceneManager;

    [SerializeField] private GameObject[] LevelChooseUI;

    private void Start()
    {
        playerData = GameManager.Instance.PlayerData;
        sceneManager = GameManager.Instance.SceneManager;

        //temporary
        for (int i = 0; i < LevelChooseUI.Length; i++)
        {
            LevelChooseUI[i].SetActive(playerData.CheckLevel(i));
        }
    }
    public void ChooseLevel(int level)
    {
        if (playerData.GetLevel(level))
        {
            sceneManager.LevelLoadScene(level);
        }
        else
        {
            Debug.Log("Level " + level + " is locked.");
        }
    }
}
