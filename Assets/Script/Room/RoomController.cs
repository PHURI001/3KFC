using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private List<Room> roomsRemaining;
    [SerializeField] private int nextLevelUnlock = 0;

    private void OnEnable()
    {
        foreach (Room room in roomsRemaining)
        {
            room.OnRoomClear += UpdateRoomClear;
        }
    }
    private void OnDisable()
    {
        foreach (Room room in roomsRemaining)
        {
            room.OnRoomClear -= UpdateRoomClear;
        }
    }

    public void DoCompleteMap()
    {
        GameManager.Instance.PlayerData.SetLevel(nextLevelUnlock);
        GameManager.Instance.SceneManager.GoToMain();
    }

    private void UpdateRoomClear(Room room)
    {
        roomsRemaining.Remove(room);

        if (roomsRemaining.Count == 0)
        {
            DoCompleteMap();
        }
    }
}
