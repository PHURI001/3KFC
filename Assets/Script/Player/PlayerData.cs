using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{

    private PlayerShowStats showStats;

    //Data
    [SerializeField] private int coin;

    [SerializeField] private int gunID;
    [SerializeField] private List<int> gunUnlock = new List<int>();

    [SerializeField] private float criticalChance = 1;
    [SerializeField] private float criticalDamage = 1;
    [SerializeField] private float dropChance = 1;

    [SerializeField] private List<bool> LevelUnlock = new List<bool>() { true };

    public static PlayerData Instance;
    public DataSave dataSave;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        dataSave = FindFirstObjectByType<DataSave>();

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

    //temporary
    public bool CheckLevel(int level)
    {
        if (LevelUnlock.Count <= level) { return false; }
        return LevelUnlock[level];
    }

    public void AddCoin(int amount)
    {
        coin += amount;

        if (showStats == null) { showStats = FindFirstObjectByType<PlayerShowStats>(); }
            
        showStats.SetCoin(coin);
    }

    public void ResetAllData()
    {
        coin = 0;

        gunID = 0;

        gunUnlock.Clear();

        criticalChance = 1;
        criticalDamage = 1;
        dropChance = 1;

        LevelUnlock.Clear();
        LevelUnlock.Add(true);

        showStats.SetCoin(coin);
    }

    public void UnlockGun(int gunID)
    {
        if (!gunUnlock.Contains(gunID))
        {
            gunUnlock.Add(gunID);
            gunUnlock.Sort();
        }
    }
}
