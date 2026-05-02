using UnityEngine;

public class Bullet_VFX : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private GameObject VFXExplode;
    [SerializeField] private GameObject VFXHit;
    private void OnEnable()
    {
        bullet.OnExplode += SpawnExplodeVFX;
        bullet.OnHit += SpawnOnHitVFX;
    }
    private void OnDisable()
    {
        bullet.OnExplode -= SpawnExplodeVFX;
        bullet.OnHit -= SpawnOnHitVFX;
    }
    private void SpawnExplodeVFX()
    {
        if (VFXExplode == null) return;
        Instantiate(VFXExplode, transform.position, Quaternion.identity);
    }

    private void SpawnOnHitVFX()
    {
        if (VFXHit == null) return;
        Instantiate(VFXHit, transform.position, transform.rotation);
    }
}
