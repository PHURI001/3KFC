using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Health = 0,
    Shield = 1,
    CritDamage = 2,
    CritChance = 3,
    DropChance = 4
}

[System.Serializable]
public class PlayerData : MonoBehaviour
{

    private PlayerShowStats showStats;

    //Data
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int maxSheild = 5;

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

    public (int,int) GetHealthShield() { return (maxHealth, maxSheild); }

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

    public void SpendCoin(int amount)
    {
        coin -= amount;

        if (showStats == null) { showStats = FindFirstObjectByType<PlayerShowStats>(); }

        showStats.SetCoin(coin);
    }

    public int GetCoins() { return coin; }

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

    private int upgradePer = 1;
    public void Upgrade(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Health:
                maxHealth += upgradePer;
                break;
            case UpgradeType.Shield:
                maxSheild += upgradePer;
                break;
            case UpgradeType.CritDamage:
                criticalDamage += 0.1f;
                break;
            case UpgradeType.CritChance:
                criticalChance += 0.1f;
                break;
            case UpgradeType.DropChance:
                dropChance += 0.1f;
                break;
        }
    }
}
