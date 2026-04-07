using System;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class Abstract_Gun : MonoBehaviour
{
    //public event Action OnShoot;
    //public event Action OnReload;

    [field: SerializeField] protected Transform shootPoint;

    public abstract void Shoot();

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    protected void SpawnBullet(GameObject bullet, Vector3 spawnPos, Vector3 dir, float speed)
    {
        GameObject obj = Instantiate(bullet, spawnPos, Quaternion.LookRotation(dir));
        if (obj.TryGetComponent<Bullet>(out Bullet comp))
        {
            comp.Init(speed);
        }
    }
}
