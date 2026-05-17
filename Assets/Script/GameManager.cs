using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(SceneManager))]
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(DataSave))]
[RequireComponent(typeof(GunPrefab))]
[RequireComponent(typeof(BulletPrefab))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InputReader InputReader;
    public SceneManager SceneManager;
    public PlayerData PlayerData;
    public PlayerShowStats showStats;
    public DataSave DataSave;
    public GunPrefab GunPrefab;
    public BulletPrefab BulletPrefab;

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
            GunPrefab = GetComponent<GunPrefab>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
