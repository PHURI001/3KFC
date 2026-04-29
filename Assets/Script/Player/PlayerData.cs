using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private PlayerShowStats showStats;

    private List<bool> LevelUnlock  = new List<bool>() { true };
    private int coin;

    private void Start()
    {
        showStats = GameManager.Instance.showStats;
        showStats.SetCoin(coin);
    }

    public void SetLevel(int level)
    {
        if (level < 0) { return; }
        while (LevelUnlock.Count <= level)
        {
            LevelUnlock.Add(false);
        }
        LevelUnlock[level - 1] = true;
    }

    public bool GetLevel(int level)
    {
        if (level < 0 || level > LevelUnlock.Count) { return false; }
        return LevelUnlock[level - 1];
    }

    public void AddCoin(int amount)
    {
        coin += amount;

        if (showStats == null) { showStats = FindFirstObjectByType<PlayerShowStats>(); }
            
        showStats.SetCoin(coin);
    }


}
