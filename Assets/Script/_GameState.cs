using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _GameState : MonoBehaviour
{
    [SerializeField] private int nextLevelUnlock;
    private Enemy enemie;

    private void Awake()
    {
        enemie = FindFirstObjectByType<Enemy>();
    }

    private void Update()
    {
        if (enemie == null)
        {
            enemie = FindFirstObjectByType<Enemy>();
            if (enemie == null)
            {
                GameManager.Instance.PlayerData.SetLevel(nextLevelUnlock);
                GameManager.Instance.SceneManager.GoToMain();
            }
        }
    }
}
