using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static Pause Instance { get; private set; }

    public GameObject PauseMenu;

    [SerializeField] AudioSource musicAudio;
    [SerializeField] Scrollbar musicVolume;

    [SerializeField] AudioSource sfxAudio;
    [SerializeField] Scrollbar sfxVolume;

    [SerializeField] CanvasGroup hudCanvasGroup;
    [SerializeField] Scrollbar hudToggle;

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

    public void ToggleMusic()
    {
        musicAudio.volume = musicVolume.value;
    }

    public void ToggleSFX()
    {
        sfxAudio.volume = sfxVolume.value;
    }

    public void ToggleHUD()
    {
        hudCanvasGroup.alpha = hudToggle.value;
    }

    public void AddMoreCoin()
    {
        GameManager.Instance.PlayerData.AddCoin(999999);
    }
}
