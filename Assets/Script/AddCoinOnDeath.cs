using UnityEngine;

public class AddCoinOnDeath : MonoBehaviour
{
    [SerializeField] private int coinReward;
    private void OnDestroy()
    {
        GameManager.Instance.PlayerData.AddCoin(coinReward);
    }
}
