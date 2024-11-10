using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalLineController : MonoBehaviour
{
    // Line Renderer component
    private LineRenderer lineRenderer;

    // Start and end points of the line
    private Vector3 startPoint;
    private Vector3 endPoint;

    // Circle parameters
    private Vector3 circleCenter;
    private float circleRadius;

    void Start()
    {
        // Get the Line Renderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Initialize start and end points of the line (adjust as needed)
        startPoint = new Vector3(-5f, 0f, 0f);
        endPoint = new Vector3(5f, 0f, 0f);

        // Set the positions for the Line Renderer
        lineRenderer.SetPositions(new Vector3[] { startPoint, endPoint });

        // Calculate circle center and radius
        circleCenter = (startPoint + endPoint) / 2f;
        circleRadius = Vector3.Distance(startPoint, endPoint) / 2f;
    }

    void OnMouseDrag()
    {
        // Calculate mouse movement
        float rotationDelta = Input.GetAxis("Mouse X");

        // Rotate the line around its midpoint
        transform.RotateAround(circleCenter, Vector3.forward, rotationDelta * 5f);

        // Update the positions of the line renderer after rotation
        lineRenderer.SetPositions(new Vector3[] { startPoint, endPoint });

        // Recalculate circle center (should remain unchanged) and radius
        circleCenter = (startPoint + endPoint) / 2f;
        circleRadius = Vector3.Distance(startPoint, endPoint) / 2f;
    }
}

