using System.Collections;
using UnityEngine;

public class MaterialBlink : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private string propertyName = "_BaseColor";
    [SerializeField] private Color blinkColor = Color.white;
    [SerializeField] private float duration = 0.1f;

    private Color originalColor;
    private Coroutine currentRoutine;

    private Material mat;

    private void Start()
    {
        mat = rend.material;

        if (mat.HasProperty(propertyName))
        {
            originalColor = mat.GetColor(propertyName);
        }
    }

    public void Play()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        if (!mat.HasProperty(propertyName)) yield break;
        mat.SetColor(propertyName, blinkColor);
        yield return new WaitForSeconds(duration);
        mat.SetColor(propertyName, originalColor);
    }
}