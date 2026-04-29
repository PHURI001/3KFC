using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class WeaponHolder : MonoBehaviour
{
    [field: SerializeField] public List<GameObject> IgnoreTargetObjects {  get; private set; }
    [field: SerializeField] public Abstract_Gun MainGun { get; private set; }

    private List<ITakeDamage> ignoreTargets;

    private void Awake()
    {
        if (ignoreTargets == null) ignoreTargets = new List<ITakeDamage>();
    }

    private void OnEnable()
    {
        UpdateIgnoreTarget();
        MainGun?.Init(ignoreTargets);
    }

    public void ShootOneTime()
    {
        MainGun.Shoot();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootOneTime();
        }
    }

    private void UpdateIgnoreTarget()
    {
        foreach (var target in IgnoreTargetObjects)
        {
            if (target.TryGetComponent(out ITakeDamage comp))
            {
                if (ignoreTargets.Contains(comp)) continue;
                ignoreTargets.Add(comp);
            }
        }
    }
}
