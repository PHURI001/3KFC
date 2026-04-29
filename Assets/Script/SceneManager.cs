using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
    }

    public void GoToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
