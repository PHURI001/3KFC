using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public event Action OnHit;
    public event Action OnDoDamage;
    public event Action OnExplode;

    [field: SerializeField] public float BaseDamage { get; private set; } = 30f;
    [field: SerializeField] public float speed { get; private set; } = 1.0f;
    [field: SerializeField] public float lifeTime { get; private set; } = 10.0f;

    [Header("Attribute")]
    [SerializeField] private Bullet_Attribute_MoveController Attribute_Move;
    [SerializeField] private Bullet_Attribute_Explosive[] Attribute_Explosive;
    [SerializeField] private Bullet_Attribute_ApplyEffect[] Attribute_ApplyEffect;
    [SerializeField] private bool isPierce = false;
    [SerializeField] private LayerMask bouncesCheckLayerMask;
    [SerializeField] private float bouncesCheckDistance = 1.5f;
    [SerializeField] private int maxBounces = 0;

    private int bounceCount = 0;
    private List<ITakeDamage> ignoreTargets = new List<ITakeDamage>();
    private Data_Stats baseStat = new Data_Stats();
    #region MainLogic
    private void Awake()
    {
        if (ignoreTargets == null) ignoreTargets = new List<ITakeDamage>();
        Init(speed);
        Destroy(gameObject, lifeTime);
    }

    public void Init(float _speed, List<ITakeDamage> _ignoreTarget, Data_Stats newStat)
    {
        ignoreTargets = _ignoreTarget;
        baseStat = newStat;
        Init(_speed);
    }

    public void Init(float _speed)
    {
        speed = _speed;

        if (Attribute_Move == null) Attribute_Move = new Bullet_Attribute_MoveController();
        Attribute_Move.Init(this);

        foreach (var att in Attribute_Explosive)
        {
            att.Init(this);
        }

        foreach (var att in Attribute_ApplyEffect)
        {
            att.Init(this);
        }
    }

    void Update()
    {
        Attribute_Move?.Tick(Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ignoreTargets.Contains(other.GetComponent<ITakeDamage>())) return;
        if (other.gameObject.CompareTag("Player")) return;

        //If have Explosive Use Explosive
        //It not Damage Direct To ITakeDamage
        if (Attribute_Explosive.Length != 0)
        {
            ActiveExplosiveAttribute(Attribute_Explosive, other.GetComponent<Enemy>());
            OnExplode?.Invoke();
        }
        else if (other.TryGetComponent<ITakeDamage>(out ITakeDamage target))
        {
            DoDamage(target, BaseDamage, other.GetComponent<Enemy>());
        }

        OnHit?.Invoke();

        if (isPierce)
        {
            return;
        }
        else if (bounceCount < maxBounces)
        {
            TryBounces();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TryBounces()
    {
        Ray ray = new Ray(transform.position - transform.forward * 0.5f, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, bouncesCheckDistance, bouncesCheckLayerMask))
        {
            Vector3 reflectDir = Vector3.Reflect(transform.forward, hit.normal);
            transform.forward = reflectDir.normalized;
        }

        bounceCount++;
    }
    #endregion
    #region Public Method
    public void DoDamage(ITakeDamage target,float NewBaseDamage, Enemy enemy)
    {
        if (ignoreTargets.Contains(target)) return;

        Data_Stats stats = new Data_Stats();
        stats.damage += baseStat.damage;
        stats.criticalChance += baseStat.criticalChance;
        stats.criticalDamage += baseStat.criticalDamage;
        stats.dropChance += baseStat.dropChance;
        stats.damage = (int)(NewBaseDamage);
        target.TakeDamage(stats);
        OnDoDamage?.Invoke();

        if (Attribute_ApplyEffect.Length == 0) return;
        foreach (var att in Attribute_ApplyEffect)
        {
            att.ApplyEffect(enemy);
        }
    }

    public void RatateTo(Quaternion newRotate)
    {
        transform.rotation = newRotate;
    }
    public void ActiveExplosiveAttribute(Bullet_Attribute_Explosive[] attribute, Enemy enemy)
    {
        foreach (var att in attribute)
        {
            att?.DoExplosive(BaseDamage, enemy);
        }
    }

    public List<ITakeDamage> FindAllItakeDamageInRange(float range)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        List<ITakeDamage> posibleTargets = new List<ITakeDamage>();

        foreach (Collider col in colliders)
        {
            if (col == null) continue;
            if (col.TryGetComponent<ITakeDamage>(out ITakeDamage comp))
            {
                if (ignoreTargets.Contains(comp)) continue;
                posibleTargets.Add(comp);
            }
        }

        return posibleTargets;
    }
    public List<Transform> FindTransformTargetInRange(float range)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        List<Transform> posibleTargets = new List<Transform>();

        foreach (Collider col in colliders)
        {
            if (col == null) continue;
            ITakeDamage comp = col.GetComponentInParent<ITakeDamage>();

            if (comp == null) continue;
            if (ignoreTargets.Contains(comp)) continue;
            posibleTargets.Add(col.transform);
        }
        return posibleTargets;
    }
    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Attribute_Move.HomingRange);

        if (Attribute_Explosive == null) return;
        foreach (var att in Attribute_Explosive)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, att.ExplosiveRange);
        }
    }
}
