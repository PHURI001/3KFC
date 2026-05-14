using System.Collections;
using UnityEngine;

public class MaterialValueLearp : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    [SerializeField] private string propertyName = "_MyFloat";
    [SerializeField] private float duration = 1f;

    private Material mat;
    private Coroutine currentRoutine;

    private void Awake()
    {
        mat = renderer.material;
    }

    public void Play()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(LerpValue(0f, 1f));
    }

    private IEnumerator LerpValue(float start, float end)
    {
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            float value = Mathf.Lerp(start, end, t);

            mat.SetFloat(propertyName, value);

            time += Time.deltaTime;
            yield return null;
        }
        mat.SetFloat(propertyName, end);
    }
}
