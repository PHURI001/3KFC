using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(SceneManager))]
[RequireComponent(typeof(PlayerData))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InputReader InputReader;
    public SceneManager SceneManager;
    public PlayerData PlayerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InputReader = GetComponent<InputReader>();
            SceneManager = GetComponent<SceneManager>();
            PlayerData = GetComponent<PlayerData>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
