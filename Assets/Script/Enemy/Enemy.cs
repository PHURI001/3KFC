using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //attributes
    [SerializeField] protected float health = 100;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float strength = 10;

    private Rigidbody rb;
    public Transform PlayerLocate;
    public NavMeshAgent Agent;

    //Public Property
    public virtual float Health { get => health; protected set => health = Mathf.Clamp(value, 0, 100); }
    public virtual float Speed { get => speed; protected set => speed = Mathf.Clamp(value, 0, 20); }
    public virtual float Strength { get => strength; protected set => strength = Mathf.Clamp(value, 0, 100); }
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Health = health;
        Speed = speed;
        Strength = strength;

        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = Speed;
        Agent.stoppingDistance = (gameObject.transform.localScale.x * gameObject.transform.localScale.z) + 0.5f;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Dead();
        }
        else
        {
            MoveToTarget();
        }
    }
    public void MoveToTarget()
    {
        Agent.SetDestination(PlayerLocate.position);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

}
