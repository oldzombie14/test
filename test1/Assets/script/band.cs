using UnityEngine;

public class band : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Vector3 startPoint; // 曲线的第一个点
    public Vector3 endPoint;   // 曲线的最后一个点

    public float a = 1f; // 二次函数参数 a
    public float b = 0f; // 二次函数参数 b
    public float c = 0f; // 二次函数参数 c

    void Start()
    {
        UpdateCurve();
    }

    void Update()
    {
        // 每帧更新曲线（可选）
        UpdateCurve();
    }

    void UpdateCurve()
    {
        float x1 = startPoint.x;
        float y1 = startPoint.y;
        float x2 = endPoint.x;
        float y2 = endPoint.y;

        int numPoints = 50; // 用于绘制曲线的点数
        lineRenderer.positionCount = numPoints;

        for (int i = 0; i < numPoints; i++)
        {
            float x = (float)i / (numPoints - 1) * (x2 - x1) + x1;
            float y = a * x * x + b * x + c;
            lineRenderer.SetPosition(i, new Vector3(y, x, 0f));
        }
    }
}
