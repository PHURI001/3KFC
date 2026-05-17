using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class WeaponHolder : MonoBehaviour
{

    [field: SerializeField] public List<GameObject> IgnoreTargetObjects {  get; private set; }
    [field: SerializeField] public GameObject GunHolder { get; private set; }
    [field: SerializeField] public GameObject GunObj { get; private set; }
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }

    private Abstract_Gun mainGun;
    private List<ITakeDamage> ignoreTargets;

    private void Awake()
    {
        if (ignoreTargets == null) ignoreTargets = new List<ITakeDamage>();
        //mainGun = GunObj.GetComponent<Abstract_Gun>();
    }
    private void Start()
    {
        //SetNewWeapon(GunObj, BulletPrefab);
    }
    private void OnEnable()
    {
        UpdateIgnoreTarget();
        mainGun?.Init(ignoreTargets , new Data_Stats());
    }

    public void Shoot(bool toggle)
    {
        mainGun.SetGunFire(toggle);
    }

    public void SetNewWeapon(GameObject gunPrefab, GameObject bulletPrefab)
    {
        GameObject gunObj = Instantiate(gunPrefab, GunHolder.transform.position, Quaternion.identity);
        gunObj.transform.parent = GunHolder.transform;
        //gunObj.transform.position = Vector3.zero;
        GunObj = gunObj;
        mainGun = gunObj.GetComponent<Abstract_Gun>();
        mainGun.Bullet = bulletPrefab;

        if (mainGun == null) mainGun = GunObj.GetComponent<Abstract_Gun>();
        Data_Stats baseStat = new Data_Stats();
        (baseStat.criticalChance,baseStat.criticalDamage,baseStat.dropChance) = GameManager.Instance.PlayerData.GetData();
        mainGun?.Init(ignoreTargets , baseStat);
    }

    private void Update()
    {
        Shoot(Mouse.current.leftButton.isPressed);
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
