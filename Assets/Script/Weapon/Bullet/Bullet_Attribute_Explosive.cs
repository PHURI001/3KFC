using System;
using UnityEngine;

[Serializable]
public class Bullet_Attribute_Explosive
{
    private Bullet curretBullet;
    [Header("Stat")]
    [SerializeField] private float Range = 1f;
    [SerializeField] private float DamageMultiply = 1f;

    public void Init(Bullet newBullet)
    {
        curretBullet = newBullet;
    }
    public void DoExplosive(float rawDamage)
    {
        Vector3 pos = curretBullet.transform.position;
        Physics.OverlapSphere(pos, Range);
#warning Apply Damage To ITakeDamage
    }
}
