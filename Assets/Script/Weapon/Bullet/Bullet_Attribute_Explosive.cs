using System;
using System.Collections.Generic;
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
        List<ITakeDamage> targets = curretBullet.FindAllItakeDamageInRange(Range);
        foreach (ITakeDamage target in targets) 
        {
            target.TakeDamage(99999);
        }
#warning Apply Damage To ITakeDamage
    }
}
