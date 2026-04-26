using UnityEngine;

public abstract class Area : MonoBehaviour
{
    [SerializeField] protected GameObject ui;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }
}
