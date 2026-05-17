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
    Player player;

    //Data
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxSheild = 50;

    [SerializeField] private int coin;

    [SerializeField] private int gunID = 1;
    [SerializeField] private int bulletID = 1;
    [SerializeField] private List<int> gunUnlock = new List<int>() { 1};
    [SerializeField] private List<int> bulletUnlock = new List<int>() { 1};

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
        player = FindFirstObjectByType<Player>();

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

    public void UnlockBullet(int gunID)
    {
        if (!bulletUnlock.Contains(gunID))
        {
            bulletUnlock.Add(gunID);
            bulletUnlock.Sort();
        }
    }
    public void SetGun(int id)
    {
        gunID = id;
    }

    public void SetBullet(int id)
    {
        bulletID = id;
    }

    private int upgradeHealthValue = 5;
    private int upgradeShieldValue = 2;
    private float upgradeOtherValue = 0.1f;
    public void Upgrade(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Health:
                maxHealth += upgradeHealthValue;
                break;
            case UpgradeType.Shield:
                maxSheild += upgradeShieldValue;
                break;
            case UpgradeType.CritDamage:
                criticalDamage += upgradeOtherValue;
                break;
            case UpgradeType.CritChance:
                criticalChance += upgradeOtherValue;
                break;
            case UpgradeType.DropChance:
                dropChance += upgradeOtherValue;
                break;
        };
        player.Init();
    }

    public (float, float, float) GetData() { return (criticalChance, criticalDamage, dropChance); }

    public int CurrentGun() { return gunID; }
    public int CurrentBullet() { return bulletID; }
    public List<int> GetGunUnlock() { return gunUnlock; }
    public List<int> GetBulletUnlock() { return bulletUnlock; }

    public void ResetData()
    {
        maxHealth = 100;
        maxSheild = 50;
        coin = 0;
        gunID = 1;
        bulletID = 1;
        gunUnlock.Clear();
        gunUnlock.Add(1);
        bulletUnlock.Clear();
        bulletUnlock.Add(1);
        criticalChance = 1;
        criticalDamage = 1;
        dropChance = 1;
        LevelUnlock.Clear();
        LevelUnlock.Add(true);
        showStats.SetCoin(coin);
    }
}
