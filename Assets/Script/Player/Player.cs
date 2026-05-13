using UnityEngine;
using System.IO;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(LookAt))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerShowStats showStats;

    [Header("Player Stats")]
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int _currentHealth;
    private int currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    [SerializeField] private int maxSheild = 5;
    [SerializeField] private int _currentSheild;
    private int currentSheild
    {
        get { return _currentSheild; }
        set { _currentSheild = Mathf.Clamp(value, 0, maxSheild); }
    }

    [SerializeField] private float criticalDamage = 1f;
    [SerializeField] private float criticalChance = 1f;
    [SerializeField] private float dropChance = 1f;

    [SerializeField] private bool isGameOver = false;

    private float shieldRegenDelay = 5f;
    private Coroutine shieldRegenCoroutine;

    private void Start()
    {
        LoadGame();
        currentHealth = maxHealth;
        currentSheild = maxSheild;

        showStats = GameManager.Instance.showStats;
        ShowStats();
    }

    public void TakeDamage(Data_Stats dataDamage)
    {
        int damage = dataDamage.damage;
        if (currentSheild > 0)
        {
            if (damage <= currentSheild)
            {
                currentSheild -= damage;
                damage = 0;
            }
            else if (damage >= currentSheild)
            {
                damage -= currentSheild;
                currentSheild = 0;
            }
        }

        if (damage > 0)
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            isGameOver = true;
            Die();
        }
        //Debug.Log($"Player Health:{currentHealth}, Shield:{currentSheild}");


        if (shieldRegenCoroutine != null)
        {
            StopCoroutine(shieldRegenCoroutine);
        }
        shieldRegenCoroutine = StartCoroutine(ShieldRegen());

        ShowStats();
    }

    public void Die()
    {
        // We can add later
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        Debug.Log("Player has died.");
    }


    public bool IsGameOver() { return isGameOver; }

    public Data_Stats GetDataStats()
    {
        Data_Stats stats = new Data_Stats();
        stats.criticalDamage = criticalDamage;
        stats.criticalChance = criticalChance;
        stats.dropChance = dropChance;
        return stats;
    }

    public void SaveGame()
    {
        GameData data = new GameData();
        data.criticalDamage = criticalDamage;
        data.criticalChance = criticalChance;
        data.dropChance = dropChance;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            criticalDamage = data.criticalDamage;
            criticalChance = data.criticalChance;
            dropChance = data.dropChance;
        }
    }

    private void ShowStats()
    {
        showStats.SetHealth(currentHealth);
        showStats.SetShield(currentSheild);
    }

    IEnumerator ShieldRegen()
    {
        yield return new WaitForSeconds(shieldRegenDelay);

        while (currentSheild < maxSheild)
        {
            yield return new WaitForSeconds(1f);
            currentSheild += 1;
            ShowStats();
        }
        shieldRegenCoroutine = null;
    }
}
