using UnityEngine;

public class Bullet_VFX : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private GameObject VFX;
    private void OnEnable()
    {
        bullet.OnExplode += SpawnExplodeVFX;
    }
    private void OnDisable()
    {
        bullet.OnExplode -= SpawnExplodeVFX;
    }
    private void SpawnExplodeVFX()
    {
        Instantiate(VFX, transform.position, Quaternion.identity);
    }
}
