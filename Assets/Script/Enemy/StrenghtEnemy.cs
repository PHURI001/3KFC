using UnityEngine;

public class StrenghtEnemy : Enemy
{

    public override float Health { get => health; protected set => health = Mathf.Clamp(value, 0, 200); }
    public override float Speed { get => speed; protected set => speed = Mathf.Clamp(value, 0, 20); }
    public override float Strength { get => strength; protected set => strength = Mathf.Clamp(value, 0, 75); }
    protected override void Awake()
    {
        speed = 10;
        strength = 20;
        health = 100;
        base.Awake();
    }
}
