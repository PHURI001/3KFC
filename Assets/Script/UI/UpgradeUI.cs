using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    PlayerData PlayerData;

    [SerializeField] private int upgradeCost = 50;

    [SerializeField]private TMP_Text coinText;

    private void Start()
    {
        PlayerData = GameManager.Instance.PlayerData;

        CoinUpdate();
    }

    private bool CanBuying()
    {
        if (PlayerData.GetCoins() < upgradeCost) { return false; }
        return true;
    }

    public void Upgrade(int type)
    {
        if (!CanBuying()) { return; }
        PlayerData.SpendCoin(upgradeCost);
        PlayerData.Upgrade((UpgradeType)type);
        CoinUpdate();
    }

    public void CoinUpdate()
    {
        coinText.text = "Coins: " + PlayerData.GetCoins();
    }
}
