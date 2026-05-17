using UnityEngine;

public class MapDataTracker : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private void OnEnable()
    {
        enemy.OnCoinDrop += AddCoinDropData;
        enemy.OnTakeDamage += AddDamageDealData;
    }

    private void OnDisable()
    {
        enemy.OnCoinDrop -= AddCoinDropData;
        enemy.OnTakeDamage -= AddDamageDealData;
    }


    public void AddCoinDropData(int amount)
    {
        RoomController.Instance.TotalCoinEarn += amount;
    }

    public void AddDamageDealData(int amount)
    {
        RoomController.Instance.TotalDamageDeal += amount;
    }
}
