using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bullet_Attribute_Explosive
{
    private Bullet curretBullet;
    [Header("Stat")]
    [field: SerializeField] public float ExplosiveRange { get; private set; } = 150f;
    [SerializeField] private float DamageMultiply = 1f;

    public void Init(Bullet newBullet)
    {
        curretBullet = newBullet;
    }
    public void DoExplosive(float rawDamage, Enemy enemy)
    {
        List<ITakeDamage> targets = curretBullet.FindAllItakeDamageInRange(ExplosiveRange);
        foreach (ITakeDamage target in targets)
        {
            curretBullet.DoDamage(target, curretBullet.BaseDamage * DamageMultiply, enemy);
        }
    }
}
