using System;
using UnityEngine;

public class Gun_VFX : MonoBehaviour
{
    [SerializeField] private Abstract_Gun mainGun;
    [SerializeField] private GameObject VFXShoot;

    private void OnEnable()
    {
        mainGun.OnShoot += SpawnShootVFX;
    }

    private void OnDisable()
    {
        mainGun.OnShoot -= SpawnShootVFX;
    }

    private void SpawnShootVFX()
    {
        Instantiate(VFXShoot, mainGun.transform.position, mainGun.transform.rotation);
    }
}
