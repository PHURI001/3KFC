using System;
using System.Collections;
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
    [SerializeField] private int DamageTaken = 0;
    [SerializeField] private ParticleSystem slowVFX;
 
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
    [field: SerializeField] public float SlowTimeRemaning { get; protected set; } = 0;

    private float originalSpeed;
    private float slowSpeed;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Health = health;
        Speed = speed;
        Strength = strength;
        originalSpeed = speed;

        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = Speed;
        //Agent.stoppingDistance = ((gameObject.transform.localScale.x + gameObject.transform.localScale.z) / 2) + 15;

        PlayerLocate = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        MoveToTarget();

        if (SlowTimeRemaning > 0)
        {
            SlowTimeRemaning -= Time.deltaTime;
            speed = slowSpeed;
            if (!slowVFX.isPlaying)
                slowVFX.Play();
        }
        else
        {
            speed = originalSpeed;
            if (!slowVFX.isStopped)
                slowVFX.Stop();
        }

        Agent.speed = speed;
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

    public IEnumerator Dead()
    {
        yield return null;
        //wave.enemyCount = -1;
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(Data_Stats dataDamage)
    {
        if (Health <= 0) return;

        //Calculate Damage
        bool isCritical = UnityEngine.Random.Range(0f, 1f) < dataDamage.criticalChance;
        int finalDamage;
        Debug.Log(dataDamage.damage);
        if (isCritical)
        {
            finalDamage = Mathf.RoundToInt(dataDamage.damage * dataDamage.criticalDamage);
        }
        else
        {
            finalDamage = dataDamage.damage;
        }
        OnTakeDamage?.Invoke(finalDamage);
        DamageTaken += finalDamage;
        //Check Death
        if (health - finalDamage <= 0)
        {
            Health -= finalDamage;

            float newCoinDropChance = coinDropChange + dataDamage.dropChance;
            if ( UnityEngine.Random.Range(0f, 1f) < newCoinDropChance)
            {
                OnCoinDrop?.Invoke(coinDropAmount);
                GameManager.Instance.PlayerData.AddCoin(coinDropAmount);
            }
            StartCoroutine(Dead());
        }
        else
        {
            Health -= finalDamage;
        }
    }

    public void Slow(float speedMultiply,float duration)
    {
        SlowTimeRemaning = duration;
        slowSpeed = speedMultiply;
    }
}
