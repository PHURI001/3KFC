using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private string[] LevelSceneName;

    public void GoToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void LevelLoadScene(int level)
    {
        if (level < 0 || level > LevelSceneName.Length) { return; }
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelSceneName[level - 1]);
    }
}
