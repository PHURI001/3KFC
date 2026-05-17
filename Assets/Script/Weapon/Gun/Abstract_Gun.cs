using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Abstract_Gun : MonoBehaviour
{
    public event Action OnShoot;
    //public event Action OnReload;

    [field: SerializeField] public Transform shootPoint { get; private set; }
    [field: SerializeField] public GameObject Bullet { get; set; }

    [SerializeField]private float reloadTime = 1f;

    private List<ITakeDamage> ignoreTargets;
    private float nextTimeShoot = float.MinValue;
    private bool isFiring = false;
    public void SetGunFire(bool toggle)
    {
        isFiring = toggle;
    }

    public abstract void Shoot();

    private void Update()
    {
        if (Time.time < nextTimeShoot) return;

        if (isFiring)
        {
            Shoot();
            nextTimeShoot = Time.time + reloadTime;
        }
    }

    public void Init(List<ITakeDamage> _ignoreTargets)
    {
        ignoreTargets = _ignoreTargets;
    }

    protected void SpawnBullet(GameObject bullet, Vector3 spawnPos, Vector3 dir, float speed)
    {
        GameObject obj = Instantiate(bullet, spawnPos, Quaternion.LookRotation(dir));
        if (obj.TryGetComponent<Bullet>(out Bullet comp))
        {
            comp.Init(speed, ignoreTargets);
        }

        OnShoot?.Invoke();
    }
}
