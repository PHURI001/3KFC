using System.Collections.Generic;
using UnityEngine;

public class Gun_PatternShot : Abstract_Gun
{
    [SerializeField] private SO_SingelShotGun data;
    [SerializeField] private List<Transform> spawnPoints;
    public override void Shoot()
    {
        foreach (Transform t in spawnPoints)
        {
            SpawnBullet(Bullet, t.position, transform.forward, data.Speed);
        }
    }
}
