using UnityEngine;

public class MainArea : MonoBehaviour
{
    [SerializeField] protected GameObject ui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ui.SetActive(false);
        }
    }
}
