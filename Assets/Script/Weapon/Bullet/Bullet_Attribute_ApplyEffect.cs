using System;
using UnityEngine;

[Serializable]
public class Bullet_Attribute_ApplyEffect
{
    private Bullet curretBullet;
    public void Init(Bullet newBullet)
    {
        curretBullet = newBullet;
    }

    public void ApplyEffect(ITakeDamage target)
    {
#warning Do Apply Effect
    }

}
