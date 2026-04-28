using UnityEngine;

public class Gun_SpreadShot : Abstract_Gun
{
    [SerializeField] protected SO_SpreadShotGun data;
    public override void Shoot()
    {
        int bulletCount = data.BulletToSpawn;

        if (bulletCount <= 0) return;
        float angleStep = 0f;
        float startAngle = 0f;


        if (bulletCount > 1)
        {
            angleStep = data.Angle / (bulletCount - 1);
            startAngle = -data.Angle / 2f;
        }
        else
        {
            SpawnBullet(data.Bullet, shootPoint.position, transform.forward, data.Speed);
        }

        for (int i = 0; i < bulletCount; i++)
        {
            float currentAngle = startAngle + angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
            Vector3 dir = rotation * shootPoint.forward;
            SpawnBullet(data.Bullet, shootPoint.position, dir, data.Speed);
        }
    }
}
