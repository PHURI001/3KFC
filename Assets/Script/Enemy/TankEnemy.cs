using UnityEngine;

public class TankEnemy : Enemy
{
    public override float Health { get => health; protected set => health = Mathf.Clamp(value, 0, 300); }
    public override float Speed { get => speed; protected set => speed = Mathf.Clamp(value, 0, 10); }
    public override float Strength { get => strength; protected set => strength = Mathf.Clamp(value, 0, 50); }
    protected override void Awake()
    {
        speed = 3;
        strength = 5;
        health = 175;
        base.Awake();
    }

}
