using Unity.VisualScripting;
using UnityEngine;

public class GunStorage : MonoBehaviour
{
    public GunInfo[] gunInfos;

    public Transform content;
    public GameObject ui;

    private void Start()
    {
        for (int i = 0; i < gunInfos.Length; i++)
        {
            GameObject obj = Instantiate(ui, content);
            obj.GetComponent<GunList>().UpdateInfo(gunInfos[i]);
        }
    }
}
