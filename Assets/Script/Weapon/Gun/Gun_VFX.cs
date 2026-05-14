using System;
using UnityEngine;

public class Gun_VFX : MonoBehaviour
{
    [SerializeField] private Abstract_Gun mainGun;
    [SerializeField] private GameObject VFXShoot;
    [SerializeField] private ParticleSystem VFXBulletShells;

    private void OnEnable()
    {
        mainGun.OnShoot += SpawnShootVFX;
        mainGun.OnShoot += PlayBulletShellVFX;
    }

    private void OnDisable()
    {
        mainGun.OnShoot -= SpawnShootVFX;
        mainGun.OnShoot -= PlayBulletShellVFX;
    }

    private void SpawnShootVFX()
    {
        Instantiate(VFXShoot, mainGun.transform.position, mainGun.transform.rotation);
    }

    private void PlayBulletShellVFX()
    {
        VFXBulletShells.Play();
    }
}
