using UnityEngine;

public class GunPrefab : MonoBehaviour
{
    [System.Serializable]
    public class GunBox
    {
        public GameObject gunPrefab;
        public int id;
    }

    public GunBox[] gunBoxes;

    public GameObject GetGunPrefab(int id)
    {
        foreach (GunBox gun in gunBoxes)
        {
            if (gun.id == id)
            {
                return gun.gunPrefab;
            }
        }
        Debug.Log("No Correct Gun ID " + id);
        return gunBoxes[0].gunPrefab;
    }
}
