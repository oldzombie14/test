using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TetrahedronController : MonoBehaviour
{
    public float sensitivity = 1.0f; // Sensitivity of mouse movement

    private LineRenderer lineRenderer;
    private Vector3[] vertices; // Array to hold vertex positions

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 4; // Four vertices for a tetrahedron

        // Initialize tetrahedron vertices
        vertices = new Vector3[]
        {
            new Vector3(-2f, 0f, -Mathf.Sqrt(3f)*2/3f),    // Base vertex 1
            new Vector3(2f, 0f, -Mathf.Sqrt(3f)*2/3f),     // Base vertex 2
            new Vector3(0f, 0f, 4 * Mathf.Sqrt(3f)/3f),  // Base vertex 3
            new Vector3(0f, 2f, 0f)                     // Top peak vertex
        };

        UpdateLineRenderer(); // Update Line Renderer with initial vertices
    }

    void Update()
    {
        // Get mouse input for vertical movement
        float mouseY = Input.GetAxis("Mouse Y");

        // Update top peak vertex based on mouse input
        vertices[3] += Vector3.up * mouseY * sensitivity;

        // Update Line Renderer with new vertices
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        lineRenderer.SetPositions(vertices);
    }
}
