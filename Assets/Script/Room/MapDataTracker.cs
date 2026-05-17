using UnityEngine;

public class MapDataTracker : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        enemy.OnCoinDrop += AddCoinDropData;
        enemy.OnTakeDamage += AddDamageDealData;
    }

    private void OnDisable()
    {
        Debug.Log("Reference" + enemy);
        enemy.OnCoinDrop -= AddCoinDropData;
        enemy.OnTakeDamage -= AddDamageDealData;
    }


    public void AddCoinDropData(int amount)
    {
        RoomController.Instance.TotalCoinEarn += amount;
    }

    public void AddDamageDealData(int amount,bool isCri)
    {
        RoomController.Instance.TotalDamageDeal += amount;
    }
}
