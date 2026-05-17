using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    public event Action<int> OnTakeDamage;
    public event Action<int> OnCoinDrop;
    public event Action OnDeath;

    //attributes
    [SerializeField] protected float health = 100;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float strength = 5;
 
    private Rigidbody rb;
    public Transform PlayerLocate;
    public NavMeshAgent Agent;
    //public Wave wave;

    //Public Property
    public virtual float Health { get => health; protected set => health = Mathf.Clamp(value, 0, 100); }
    public virtual float Speed { get => speed; protected set => speed = Mathf.Clamp(value, 0, 20); }
    public virtual float Strength { get => strength; protected set => strength = Mathf.Clamp(value, 0, 100); }
    [field: SerializeField] public int coinDropAmount { get; protected set; } = 10;
    [field: SerializeField] public float coinDropChange { get; protected set; } = 0.1f;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Health = health;
        Speed = speed;
        Strength = strength;

        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = Speed;
        Agent.stoppingDistance = ((gameObject.transform.localScale.x + gameObject.transform.localScale.z) / 2) + 15;

        PlayerLocate = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        MoveToTarget();
    }

#warning temporary
    //temporary
    public Data_Stats GetDataStats()
    {
        Data_Stats stats = new Data_Stats();
        stats.damage = (int)Strength;
        return stats;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(GetDataStats());
            }
        }
    }
    public void MoveToTarget()
    {
        if (PlayerLocate != null)
        {
            Agent.SetDestination(PlayerLocate.position);
        }
    }

    public void Dead()
    {
        //wave.enemyCount = -1;
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(Data_Stats dataDamage)
    {
        //Calculate Damage
        bool isCritical = UnityEngine.Random.Range(0f, 1f) < dataDamage.criticalChance;
        int finalDamage;
        if (isCritical)
        {
            finalDamage = Mathf.RoundToInt(dataDamage.damage * dataDamage.criticalDamage);
        }
        else
        {
            finalDamage = dataDamage.damage;
        }
        OnTakeDamage?.Invoke(finalDamage);

        //Check Death
        if (health - finalDamage <= 0)
        {
            float newCoinDropChance = coinDropChange + dataDamage.dropChance;
            if ( UnityEngine.Random.Range(0f, 1f) >= newCoinDropChance)
            {
                GameManager.Instance.PlayerData.AddCoin(coinDropAmount);
                OnCoinDrop?.Invoke(coinDropAmount);
            }
            Dead();
        }
        else
        {
            Health -= finalDamage;
        }
    }
}
