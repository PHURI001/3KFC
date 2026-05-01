using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Player player;

    [Header("Camera Settings")]
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        if(player == null)
            player = FindFirstObjectByType<Player>();
        if(target == null)
            target = player.transform;
        if(offset.y <= 0)
            offset.y = 10f;
    }

    private void LateUpdate()
    {
        transform.position = offset + target.position;
    }
}
