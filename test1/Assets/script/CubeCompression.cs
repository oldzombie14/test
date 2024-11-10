using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    private enum CompressionState
    {
        Cube,
        Plane,
        Line
    }

    private CompressionState currentState = CompressionState.Cube;
    private float compressionStep = 0.9f; // Step amount for compression
    private float rotationMin = 5f;
    private float rotationMax = 15f;

    private void OnMouseDown()
    {
        // Rotate the cube by a small random degree in a random direction
        float rotationAngle = Random.Range(rotationMin, rotationMax);
        Vector3 rotationAxis = Random.insideUnitSphere.normalized;
        transform.Rotate(rotationAxis, rotationAngle, Space.World);

        // Perform compression based on current state
        switch (currentState)
        {
            case CompressionState.Cube:
                // Transform into a plane by scaling along a fixed direction (e.g., Y axis)
                transform.localScale -= new Vector3(0, compressionStep, 0);
                if (transform.localScale.y <= 0.1f)
                {
                    currentState = CompressionState.Plane;
                    Debug.Log("Cube compressed into a plane.");
                }
                break;
            case CompressionState.Plane:
                // Continue compressing into a line
                transform.localScale -= new Vector3(0, 0, compressionStep);
                if (transform.localScale.z <= 0.01f)
                {
                    currentState = CompressionState.Line;
                    Debug.Log("Plane compressed into a line.");
                }
                break;
            case CompressionState.Line:
                // Additional action when it's already a line (if needed)
                break;
        }
    }
}
