using UnityEngine;
using static GunPrefab;

public class BulletPrefab : MonoBehaviour
{
    [System.Serializable]
    public class BulletBox
    {
        public GameObject bulletPrefab;
        public int id;
    }

    public BulletBox[] bulletBoxes;

    public GameObject GetGunPrefab(int id)
    {
        foreach (BulletBox bul in bulletBoxes)
        {
            if (bul.id == id)
            {
                return bul.bulletPrefab;
            }
        }
        Debug.Log("No Correct Gun ID " + id);
        return bulletBoxes[0].bulletPrefab;
    }
}
