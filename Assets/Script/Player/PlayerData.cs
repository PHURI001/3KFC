using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private List<bool> LevelUnlock  = new List<bool>() { true };

    private void Awake()
    {
        if (LevelUnlock == null)
        {
            LevelUnlock = new List<bool>();
            LevelUnlock.Add(true);
        }
    }

    public void SetLevel(int level)
    {
        if (level < 0) { return; }
        while (LevelUnlock.Count <= level)
        {
            LevelUnlock.Add(false);
        }
        LevelUnlock[level] = true;
    }

    public bool GetLevel(int level)
    {
        if (level < 0 || level > LevelUnlock.Count) { return false; }
        return LevelUnlock[level - 1];
    }
}
