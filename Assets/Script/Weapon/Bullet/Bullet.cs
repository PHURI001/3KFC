using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event Action OnHit;
    public event Action OnExplode;

    [field: SerializeField] public float BaseDamage { get; private set; } = 30f;
    [field: SerializeField] public float speed { get; private set; } = 1.0f;

    [Header("Attribute")]
    [SerializeField] private Bullet_Attribute_MoveController Attribute_Move;
    [SerializeField] private Bullet_Attribute_Explosive[] Attribute_Explosive;
    [SerializeField] private Bullet_Attribute_ApplyEffect[] Attribute_ApplyEffect;
    [SerializeField] bool IsPierce = false;

    private List<ITakeDamage> ignoreTargets;
    private void Awake()
    {
        Init(speed);
        if (ignoreTargets == null) ignoreTargets = new List<ITakeDamage>();
    }

    public void Init(float _speed, List<ITakeDamage> _ignoreTarget)
    {
        ignoreTargets = _ignoreTarget;
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
        //If have Explosive Use Explosive
        //It not Damage Direct To ITakeDamage
        if (Attribute_Explosive.Length != 0)
        {
            ActiveExplosiveAttribute(Attribute_Explosive);
            OnExplode?.Invoke();
            Debug.Log(other.name);
        }
        else if (other.TryGetComponent<ITakeDamage>(out ITakeDamage target))
        {
            DoDamage(target, BaseDamage);
        }

        if (IsPierce == false)
        {
            Destroy(gameObject);
        }

        OnHit?.Invoke();
    }

    #region Public Method
    public void DoDamage(ITakeDamage target,float NewBaseDamage)
    {
        if (ignoreTargets.Contains(target)) return;

        Data_Stats stats = new Data_Stats();
        stats.damage = (int)(NewBaseDamage);
        target.TakeDamage(stats);

        if (Attribute_ApplyEffect.Length == 0) return;
        foreach (var att in Attribute_ApplyEffect)
        {
            att.ApplyEffect(target);
        }
    }

    public void RatateTo(Quaternion newRotate)
    {
        transform.rotation = newRotate;
    }
    public void ActiveExplosiveAttribute(Bullet_Attribute_Explosive[] attribute)
    {
        foreach (var att in attribute)
        {
            att?.DoExplosive(BaseDamage);
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
            if (col.TryGetComponent<ITakeDamage>(out ITakeDamage comp))
            {
                if (ignoreTargets.Contains(comp)) continue;
                //Find Target That Have ITakeDamage
                posibleTargets.Add(col.transform);
            }
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
