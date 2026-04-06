using UnityEngine;

[CreateAssetMenu(menuName = "GunData/Multiple Shot GunData", fileName = "New Multipl Shot GunData")]
public class SO_MultipleShotGun : Abstrac_SO_BasicGun
{
    [field: SerializeField][Min(1)] public int BulletToSpawn { get; protected set; } = 1;
    [field: SerializeField][Min(0.01f)] public float DelayInterval { get; protected set; }
}
