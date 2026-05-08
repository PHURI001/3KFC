using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Room : MonoBehaviour
{
    // -------------- API --------------
    public event Action<Room> OnRoomClear;

    [SerializeField] private WaveSpawnManager waveSpawnManager;

    private bool isClear = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isClear) return;

        if (other.TryGetComponent<Player>(out Player player))
        {
            DoStartRoom();
            RoomClear();
        }
    }

    private void DoStartRoom()
    {
        Debug.Log("Room Has BeenStart");
    }

    private void RoomClear()
    {
        Debug.Log("Room Has Clear");

        isClear = true;
        OnRoomClear?.Invoke(this);
    }
}
