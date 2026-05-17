using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    PlayerData playerData;

    [System.Serializable]
    public class PlayerSaveData
    {
        public int maxHealth;
        public int maxSheild;

        public int coin;

        public int gunID;
        public int bulletID;

        public List<int> gunUnlock;
        public List<int> bulletUnlock;

        public float criticalChance;
        public float criticalDamage;
        public float dropChance;

        public List<bool> LevelUnlock;
    }

    private void Start()
    {
        playerData = PlayerData.Instance;
    }

    public void SaveData()
    {
        if (playerData == null)
        {
            playerData = GameManager.Instance.PlayerData;
        }

        PlayerSaveData data = new PlayerSaveData();

        (data.maxHealth, data.maxSheild) = playerData.GetHealthShield();

        data.coin = playerData.GetCoins();

        data.gunID = playerData.CurrentGun();
        data.bulletID = playerData.CurrentBullet();

        data.gunUnlock = new List<int>(playerData.GetGunUnlock());
        data.bulletUnlock = new List<int>(playerData.GetBulletUnlock());

        (data.criticalChance,
         data.criticalDamage,
         data.dropChance) = playerData.GetData();

        data.LevelUnlock = new List<bool>();

        int i = 1;

        while (playerData.GetLevel(i))
        {
            data.LevelUnlock.Add(true);
            i++;
        }

        string json = JsonUtility.ToJson(data, true);

        string path = Application.persistentDataPath +
                      Path.AltDirectorySeparatorChar +
                      "SaveData.json";

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write(json);
        }

        Debug.Log("Save Complete");
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath +
                      Path.AltDirectorySeparatorChar +
                      "SaveData.json";

        if (!File.Exists(path))
        {
            Debug.Log("No Save File");
            return;
        }

        string json = string.Empty;

        using (StreamReader reader = new StreamReader(path))
        {
            json = reader.ReadToEnd();
        }

        PlayerSaveData data =
            JsonUtility.FromJson<PlayerSaveData>(json);

        playerData.isLoading = true;

        playerData.ResetData();

        // Coin
        playerData.AddCoin(data.coin);

        // Gun
        playerData.SetGun(data.gunID);
        playerData.SetBullet(data.bulletID);

        // Unlock Gun
        foreach (int id in data.gunUnlock)
        {
            playerData.UnlockGun(id);
        }

        // Unlock Bullet
        foreach (int id in data.bulletUnlock)
        {
            playerData.UnlockBullet(id);
        }

        // Level
        for (int i = 0; i < data.LevelUnlock.Count; i++)
        {
            if (data.LevelUnlock[i])
            {
                playerData.SetLevel(i + 1);
            }
        }

        // Upgrade Stats
        while (playerData.GetHealthShield().Item1 < data.maxHealth)
        {
            playerData.Upgrade(UpgradeType.Health);
        }

        while (playerData.GetHealthShield().Item2 < data.maxSheild)
        {
            playerData.Upgrade(UpgradeType.Shield);
        }

        while (playerData.GetData().Item1 < data.criticalChance)
        {
            playerData.Upgrade(UpgradeType.CritChance);
        }

        while (playerData.GetData().Item2 < data.criticalDamage)
        {
            playerData.Upgrade(UpgradeType.CritDamage);
        }

        while (playerData.GetData().Item3 < data.dropChance)
        {
            playerData.Upgrade(UpgradeType.DropChance);
        }

        playerData.isLoading = false;

        Debug.Log("Load Complete");
    }

    public void DeleteData()
    {
        string path = Application.persistentDataPath +
                      Path.AltDirectorySeparatorChar +
                      "SaveData.json";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        GameManager.Instance.PlayerData.ResetData();

        SaveData();

        Debug.Log("Delete Complete");
    }
}