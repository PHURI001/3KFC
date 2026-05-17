using UnityEngine;

[CreateAssetMenu(menuName = "GunData/Charge Shot GunData", fileName = "New Charge Shot GunData")]
public class SO_ChargeShot : Abstrac_SO_BasicGun
{
    [field: SerializeField] public float maxCharge { get; protected set; } = 3f;
    [field: SerializeField] public float chargeSpeed { get; protected set; } = 1f;
    [field: SerializeField] public float minFireRate { get; protected set; } = 0.3f;
    [field: SerializeField] public float maxFireRate { get; protected set; } = 0.05f;
}
