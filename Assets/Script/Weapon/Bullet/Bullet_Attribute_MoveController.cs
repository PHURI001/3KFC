using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bullet_Attribute_MoveController
{
    [Header("Homing")]
    [field: SerializeField] public float HomingRange { get; private set; } = 5f;
    [SerializeField] private float HomingStrength = 100f;
    
    private Bullet curretBullet;
    private Transform targets;
    private float targetDistanceSqr => (targets.position - curretBullet.transform.position).sqrMagnitude;
    public void Init(Bullet newBullet)
    {
        curretBullet = newBullet;
    }

    public void Tick(float deltaTime)
    {

        curretBullet.transform.Translate(Vector3.forward * (curretBullet.speed * Time.deltaTime));

        if (targets == null)
        {
            Debug.Log(HomingRange);
            Debug.Log(curretBullet.name);
            targets = FindNearestTargetInRage(HomingRange, curretBullet.transform.position);
            return;
        }

        curretBullet.RatateTo(CalculateHoming(deltaTime,targets));

        if (targetDistanceSqr > HomingRange * HomingRange)
        {
            targets = null;
        }

    }

    private Quaternion CalculateHoming(float deltaTime,Transform target)
    {
        Vector3 dir = target.position - curretBullet.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        Quaternion newRot = Quaternion.RotateTowards(curretBullet.transform.rotation, lookRot, HomingStrength * deltaTime);
        return newRot;
    }

    private Transform FindNearestTargetInRage(float Range, Vector3 startPos)
    {
        Debug.Log(1);
        List<Transform> posibleTargets = curretBullet.FindTransformTargetInRange(Range);
        Debug.Log(2);
        Transform nearestTarget = null;
        float closetDistanceSqrMagnitude = float.MaxValue;
        Debug.Log(3);
        foreach (Transform target in posibleTargets)
        {
            if (!target.gameObject.activeSelf) continue;
            float disSqrMag = (target.position - curretBullet.transform.position).sqrMagnitude;
            if (disSqrMag < closetDistanceSqrMagnitude)
            {
                closetDistanceSqrMagnitude = disSqrMag;
                nearestTarget = target;
            }
        }
        Debug.Log(4);
        return nearestTarget;
    }
}
