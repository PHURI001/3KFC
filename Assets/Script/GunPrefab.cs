using System;
using UnityEngine;

public class GunPrefab : MonoBehaviour
{
    [Serializable]
    public class GunBox
    {
        public GameObject[] gunPrefabs;
        public int id;
    }

    public GunBox[] gunBoxes;
}
