using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Gun List prefabs")]
    [SerializeField] private GameObject basicGun;
    [SerializeField] private GameObject doubleGun;
    [SerializeField] private GameObject spreadGun;

    [Header("Bullet List prefabs")]
    [SerializeField] private GameObject basicBullet;
    [SerializeField] private GameObject homingBombBullet;

    public GameObject GetGunPrefabs(GunName gunName)
    {
        GameObject gunPref = null;
        switch (gunName)
        {
            case GunName.Basic: return gunPref = basicGun;
            case GunName.Double: return gunPref = doubleGun;
            case GunName.Spread: return gunPref = spreadGun;
        }

        return gunPref;
    }

    public GameObject GetBulletPrefabs(BulletName bulletName)
    {
        GameObject bulletPref = null;
        switch (bulletName)
        {
            case BulletName.Basic: return bulletPref = basicBullet;
            case BulletName.HomingBomb: return bulletPref = homingBombBullet;
        }

        return bulletPref;
    }
}
