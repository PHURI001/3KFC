using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bullet_Attribute_MoveController
{
    [Header("Homing")]
    [SerializeField] private float Range = 1f;
    [SerializeField] private float HomingStrength = 1f;
    
    private Bullet curretBullet;
    private List<GameObject> targets;
    public void Init(Bullet newBullet)
    {
        curretBullet = newBullet;
    }

    public void Tick(float deltaTime)
    {
        //curretBullet.RatateTo(CalculateHoming(deltaTime));
    }
/*
    private Quaternion CalculateHoming(float deltaTime,Transform target)
    {
        Vector3 dir = target.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        Quaternion newRot = Quaternion.RotateTowards(curretBullet.transform.rotation, lookRot, HomingStrength * deltaTime);
        return newRot;
    }

    private Transform FindNearestTargetInRage(float Range, Vector3 startPos)
    {
        Collider[] colliders = Physics.OverlapSphere(startPos,Range);
        List<GameObject> posibleTargets = new List<GameObject>();

        foreach (Collider col in colliders)
        {
            if (col == null) continue;
            if (col.TryGetComponent<GameObject>(out GameObject comp))
            {
                posibleTargets.Add(comp);
            }
        }
#warning NeedTo new definde Target
        Transform nearestTarget;
        foreach (GameObject target in posibleTargets)
        {

        }
    }*/
}
