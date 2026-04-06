using UnityEngine;

[CreateAssetMenu(menuName = "GunData/Spread Shot GunData", fileName = "New Single Shot GunData")]
public class SO_SpreadShotGun : Abstrac_SO_BasicGun
{
    [field: SerializeField][Min(1)] public int BulletToSpawn { get; protected set; } = 1;
    [field: SerializeField][Min(0.01f)] public float Angle { get; protected set; }
}
