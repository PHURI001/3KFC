using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(SceneManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InputReader InputReader;
    public SceneManager SceneManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InputReader = GetComponent<InputReader>();
            SceneManager = GetComponent<SceneManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play()
    {

    }
}
