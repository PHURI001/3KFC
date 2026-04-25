using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float BaseDamage = 30f;
    private float speed = 1.0f;

    [Header("Attribute")]
    [SerializeField] private Bullet_Attribute_MoveController Attribute_Move;
    [SerializeField] private Bullet_Attribute_Explosive[] Attribute_Explosive;
    [SerializeField] private Bullet_Attribute_ApplyEffect[] Attribute_ApplyEffect;
    public void Init(float _speed)
    {
        speed = _speed;

        Attribute_Move.Init(this);

        foreach(var att in Attribute_Explosive)
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
        //transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        Attribute_Move?.Tick(Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Bullet -> " + name + "has no damageDealer");
        DoHit();
    }

    private void DoHit()
    {
        ActiveExplosiveAttribute(Attribute_Explosive);
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
}
