using UnityEngine;

public class LoadGun : MonoBehaviour
{
    public GameObject player;

    PlayerData playerData;
    public GunPrefab gunPrefab;

    private void Awake()
    {
        gunPrefab = GameManager.Instance.GunPrefab;
        playerData = GameManager.Instance.PlayerData;
    }

    private void Start()
    {
        //logic here

        //check current gun by using >> playerData.GetGunUnlock()
    }
}