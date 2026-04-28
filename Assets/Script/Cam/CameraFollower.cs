using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Player player;

    [Header("Camera Settings")]
    [SerializeField] private float distanceY = 12;

    private void Awake()
    {
        if(player == null)
            player = FindFirstObjectByType<Player>();
        if(target == null)
            target = player.transform;
        if(distanceY >= 0)
            distanceY = 10f;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, distanceY, target.position.z);
    }
}
