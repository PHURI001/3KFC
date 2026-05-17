using UnityEngine;
using TMPro;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_Text popUpText;
    [SerializeField] private float alphaSpeed = 0.5f;
    [SerializeField] private float moveUpSpeed = 1;

    private bool isDestroying = false;
    public void SetText(string text,Color color)
    {
        popUpText.color = color;
        popUpText.text = text;
    }

    private void Update()
    {
        if (isDestroying) return;

        transform.Translate(new Vector3(0f, moveUpSpeed * Time.deltaTime), 0f);
        canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
        if (canvasGroup.alpha <= 0)
        {
            isDestroying = true;
            Destroy(gameObject);
        }
    }
}
