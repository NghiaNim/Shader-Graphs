using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightControllers : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public float highlightSpeed = 5.0f;

    Material highlightMaterial;
    float currentHighlightAmount = 0.0f;
    Coroutine highlightCoroutine;

    private void Awake()
    {
        highlightMaterial = meshRenderer.material;
    }

    public void StartHighlight()
    {
        if (highlightCoroutine != null)
        {
            StopCoroutine(highlightCoroutine);
        }
        highlightCoroutine = StartCoroutine(Highlight(1.0f));
    }

    public void StopHighlight()
    {
        if (highlightCoroutine != null)
        {
            StopCoroutine(highlightCoroutine);
        }
        highlightCoroutine = StartCoroutine(Highlight(0.0f));
    }

    IEnumerator Highlight(float target)
    {
        while(!Mathf.Approximately(currentHighlightAmount, target))
        {
            currentHighlightAmount = Mathf.MoveTowards(currentHighlightAmount, target, highlightSpeed * Time.deltaTime);
            highlightMaterial.SetFloat("_GlowAmount", currentHighlightAmount);

            yield return null;
        }
    }
}
