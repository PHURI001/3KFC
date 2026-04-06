using UnityEngine;

public class Enemy : MonoBehaviour
{
    //attributes
    [SerializeField] protected float health = 100;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float strength = 10;

    private Rigidbody rb;
    public Transform PlayerLocate;

    //Public Property
    public virtual float Health { get => health; protected set => health = Mathf.Clamp(value, 0, 100); }
    public virtual float Speed { get => speed; protected set => speed = Mathf.Clamp(value, 0, 20); }
    public virtual float Strength { get => strength; protected set => strength = Mathf.Clamp(value, 0 , 100); }
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Health = health;
        Speed = speed;
        Strength = strength;
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
        float dist = Vector3.Distance(rb.position, PlayerLocate.position);
        if (dist > 1.25)
        {
            Vector3 newPos = Vector3.MoveTowards(rb.position, PlayerLocate.position, Speed * Time.deltaTime);
            rb.MovePosition(newPos);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

}
