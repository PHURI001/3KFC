using UnityEngine;

public class LoadGun : MonoBehaviour
{
    public GameObject player;

    PlayerData playerData;
    public GunPrefab gunPrefab;
    public BulletPrefab bulletPrefab;

    [SerializeField] private WeaponHolder weaponHolder;

    private void Start()
    {
        gunPrefab = GameManager.Instance.GunPrefab;
        bulletPrefab = GameManager.Instance.BulletPrefab;
        playerData = GameManager.Instance.PlayerData;

        //logic here
        GameObject gun = gunPrefab.GetGunPrefab(playerData.CurrentGun());
        GameObject bullet = bulletPrefab.GetGunPrefab(playerData.CurrentBullet());
        weaponHolder.SetNewWeapon(gun, bullet);

        //check current gun by using >> playerData.CurrentGun()
    }
}