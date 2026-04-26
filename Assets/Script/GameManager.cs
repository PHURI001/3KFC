using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InputReader InputReader;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InputReader = GetComponent<InputReader>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
