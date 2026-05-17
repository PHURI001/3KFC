using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Room : MonoBehaviour
{
    // -------------- API --------------
    public event Action<Room> OnRoomClear;

    [SerializeField] private WaveSpawnManager waveSpawnManager;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private GameObject[] fires;

    private bool isClear = false;
    /*private void OnTriggerEnter(Collider other)
    {
        if (isClear) return;

        if (other.TryGetComponent<Player>(out Player player))
        {
            DoStartRoom();
        }
    }*/

    private void OnEnable()
    {
        waveSpawnManager.OnStartWave += DoStartRoom;
        waveSpawnManager.OnAllwaveComplete += RoomClear;
    }

    private void OnDisable()
    {
        waveSpawnManager.OnStartWave -= DoStartRoom;
        waveSpawnManager.OnAllwaveComplete -= RoomClear;
    }

    private void DoStartRoom()
    {
        foreach (var door in doors)
        {
            door.gameObject.SetActive(true);
        }
        Debug.Log("Room Has BeenStart");
    }

    private void RoomClear()
    {
        foreach (var door in doors)
        {
            door.gameObject.SetActive(false);
        }
        foreach (var fire in fires)
        {
            fire.gameObject.SetActive(false);
        }
        Debug.Log("Room Has Clear");
        
        isClear = true;
        OnRoomClear?.Invoke(this);
    }
}
