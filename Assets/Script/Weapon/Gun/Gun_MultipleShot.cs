using UnityEngine;
using System.Collections;
public class Gun_MultipleShot : Abstract_Gun
{
    [SerializeField] protected SO_MultipleShotGun data;
    public override void Shoot()
    {
        StartCoroutine(SpawnBulletRoutine(data.BulletToSpawn, data.DelayInterval));
    }

    private IEnumerator SpawnBulletRoutine(int bulletToSpawn, float timeInterval)
    {
        for (int i = 0; i < bulletToSpawn; i++)
        {
            SpawnBullet(data.Bullet, shootPoint.position, transform.forward, data.Speed);
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
