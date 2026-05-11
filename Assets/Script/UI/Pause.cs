using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause Instance { get; private set; }

    public GameObject PauseMenu;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        
        PauseMenu.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        
        PauseMenu.SetActive(false);
    }
}
