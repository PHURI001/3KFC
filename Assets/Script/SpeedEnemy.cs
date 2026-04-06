using UnityEngine;

public class SpeedEnemy : Enemy
{
    public override float Health { get => health; protected set => health = Mathf.Clamp(value, 0, 75); }
    public override float Speed { get => speed; protected set => speed = Mathf.Clamp(value, 0, 40); }
    public override float Strength { get => strength; protected set => strength = Mathf.Clamp(value, 0, 25); }
    protected override void Awake()
    {
        speed  = 20;
        strength = 5;
        health = 50;
        base.Awake();
    }
}
