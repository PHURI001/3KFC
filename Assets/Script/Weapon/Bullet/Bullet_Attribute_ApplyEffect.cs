using System;
using UnityEngine;

[Serializable]
public class Bullet_Attribute_ApplyEffect
{
    private Bullet curretBullet;
    [SerializeField] private float SlowSpeed = 0.2f;
    [SerializeField] private float SlowDuration = 2f;
    public void Init(Bullet newBullet)
    {
        curretBullet = newBullet;
    }

    public void ApplyEffect(Enemy target)
    {
        target.Slow(SlowSpeed, SlowDuration);
    }

}
