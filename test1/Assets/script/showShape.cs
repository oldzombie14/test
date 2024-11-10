using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showShape : MonoBehaviour
{
    public LineRenderer[] lineRenderers; // Assign all 8 line renderers here
    public float fadeDuration = 1.0f; // Duration for the fade effect

    private void Start()
    {
        // Initially make all lines invisible
        SetAlpha(0);
    }
    private void Update()
    {
        /*Vector3 parentPosition = transform.position;

        // 2. ��������������
        foreach (Transform child in transform)
        {
            LineRenderer lineRenderer = child.GetComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                // ��ȡ������ľֲ�����
                Vector3[] positions = new Vector3[lineRenderer.positionCount];
                lineRenderer.GetPositions(positions);

                // ��������ľֲ�����ת��Ϊ��������
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = child.TransformPoint(positions[i]);
                }

                // ����������ת���ؾֲ�����
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = transform.InverseTransformPoint(positions[i]);
                }

                // ���ø��º�ĵ�
                lineRenderer.SetPositions(positions);
            }
        }*/
    }

    private void OnMouseDown()
    {
        // Start the fading coroutine when the cube is clicked
        StartCoroutine(FadeLines());
    }

    private IEnumerator FadeLines()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            SetAlpha(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetAlpha(1f); // Ensure alpha is fully 1 at the end
        yield return new WaitForSeconds(1f); // Optional wait to show fully visible lines
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetAlpha(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetAlpha(0f); // Ensure alpha is fully 0 at the end
    }

    private void SetAlpha(float alpha)
    {
        foreach (LineRenderer lr in lineRenderers)
        {
            Color color = lr.startColor;
            color.a = alpha;
            lr.startColor = color;
            lr.endColor = color;
        }
    }
}
