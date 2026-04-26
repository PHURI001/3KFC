using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
}
