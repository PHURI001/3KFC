using TMPro;
using UnityEngine;

public class PlayerShowStats : MonoBehaviour
{
    [SerializeField] private TMP_Text shieldText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text coinText;

    public void SetHealth(int amount)
    {
        healthText.text = $"Health: {amount}";
    }

    public void SetShield(int amount)
    {
        shieldText.text = $"Shield: {amount}";
    }

    public void SetCoin(int amount)
    {
        coinText.text = $"Coins: {amount}";
    }
}
