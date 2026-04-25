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

}
