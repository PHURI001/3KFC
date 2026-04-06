using UnityEngine;

public class Gun_SingleShot : Abstract_Gun
{
    [SerializeField] protected SO_SingelShotGun data;
    public override void Shoot()
    {
        SpawnBullet(data.Bullet, shootPoint.position, transform.forward, data.Speed);
    }
}
