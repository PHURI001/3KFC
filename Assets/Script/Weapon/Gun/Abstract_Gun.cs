using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Abstract_Gun : MonoBehaviour
{
    //public event Action OnShoot;
    //public event Action OnReload;

    [field: SerializeField] protected Transform shootPoint;
    private List<ITakeDamage> ignoreTargets;

    public abstract void Shoot();

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
    }
}
