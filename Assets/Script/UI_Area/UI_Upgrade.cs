using UnityEngine;

public class UI_Upgrade : MonoBehaviour
{
    PlayerData playerData;
    private float critChance;
    private float critDmg;
    private float dropChance;
    private int coin;

    public Data_Stats stats;
    public PlayerData playerdata;
    public Player player;

    private void Start()
    {
        playerData = PlayerData.Instance;
    }
    private void Update()
    {
        (critChance, critDmg, dropChance) = playerData.GetStat();
        coin = playerData.GetCoin();
    }
    public void HealthUpgrade()
    {
        if (coin == 10)
        {
            Debug.Log("Up Health");
        }
    }

    public void CritChanceUpgrade()
    {
        if (coin == 10)
        {
            critChance += 1;
            coin -= 10;
        }
    }

    public void CritDamageUpgrade()
    {
        if (coin == 10)
        {
            critDmg += 5;
            coin -= 10;
            Debug.Log("Buy");
        }
        else
        {
            Debug.Log("Not  Enoght");
        }
    }

    public void DropChanceUpgrade()
    {
        if (coin == 10)
        {
            dropChance += 1;
            coin -= 10;
        }
    }
    public (float, float, float) GetStat() { return (critChance, critDmg, dropChance); }
    public int GetCoin() {  return coin; }

    
}
