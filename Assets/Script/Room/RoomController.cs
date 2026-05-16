using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private EndGameUI endGameUI;

    [Header("Map Room")]
    [SerializeField] private List<Room> roomsRemaining;
    [SerializeField] private int nextLevelUnlock = 0;

    [Header("Other Data")]
    [field:SerializeField] public int TotalDamageDeal {  get; set; }
    [field:SerializeField] public int TotalCoinEarn {  get; set; }
    [field:SerializeField] public float TimeToClear {  get; private set; }
    [field: SerializeField] public bool IsMapClear { get; private set; } = false;

    private float startTime = float.MinValue;
    private float endTime = float.MinValue;

    private void Start()
    {
        startTime = Time.time;
    }

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
        IsMapClear = true;
        endTime = Time.time;
        TimeToClear = endTime - startTime;

        GameManager.Instance.PlayerData.SetLevel(nextLevelUnlock);
        endGameUI.gameObject.SetActive(true);
        endGameUI.OpenUI(TimeToClear, TotalCoinEarn, TotalDamageDeal);
        //GameManager.Instance.SceneManager.GoToMain();
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
