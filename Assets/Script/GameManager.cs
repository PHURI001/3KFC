using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(SceneManager))]
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(DataSave))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InputReader InputReader;
    public SceneManager SceneManager;
    public PlayerData PlayerData;
    public PlayerShowStats showStats;
    public DataSave DataSave;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InputReader = GetComponent<InputReader>();
            SceneManager = GetComponent<SceneManager>();
            PlayerData = GetComponent<PlayerData>();
            showStats = GetComponentInChildren<PlayerShowStats>();
            DataSave = GetComponent<DataSave>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
