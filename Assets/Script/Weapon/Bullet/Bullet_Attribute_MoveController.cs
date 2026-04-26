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
    public void Init(Bullet newBullet)
    {
        curretBullet = newBullet;
    }

    public void Tick(float deltaTime)
    {
        curretBullet.transform.Translate(Vector3.forward * (curretBullet.speed * Time.deltaTime));

        if (targets == null)
        {
            targets = FindNearestTargetInRage(HomingRange, curretBullet.transform.position);
            return;
        }

        curretBullet.RatateTo(CalculateHoming(deltaTime,targets));
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
        List<Transform> posibleTargets = curretBullet.FindTransformTargetInRange(Range);

        Transform nearestTarget = null;
        float closetDistanceSqrMagnitude = float.MaxValue;

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

        return nearestTarget;
    }
}
