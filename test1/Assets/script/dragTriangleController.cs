using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragTriangleController : MonoBehaviour
{
    public GameObject trianglePlane; // Reference to the triangle plane GameObject

    private Vector3[] baseTriangleVertices = new Vector3[]
    {
        new Vector3(1f, 0f, 0f),
        new Vector3(0f, 1f, 0f),
        new Vector3(-1f, 0f, 0f)
    };

    private Vector3[] tetrahedronVertices;
    private int[] tetrahedronTriangles;

    void Start()
    {
        // Initialize tetrahedron vertices (assuming a regular tetrahedron)
        CalculateTetrahedron();
    }

    void Update()
    {
        // Example dragging implementation
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set a distance from the camera

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Update triangle plane vertices based on mouse drag (example code)
            Vector3 center = (baseTriangleVertices[0] + baseTriangleVertices[1] + baseTriangleVertices[2]) / 3f;
            Vector3 offset = worldPosition - center;

            for (int i = 0; i < baseTriangleVertices.Length; i++)
            {
                baseTriangleVertices[i] += offset;
            }

            // Recalculate tetrahedron vertices
            CalculateTetrahedron();

            // Update the triangle plane mesh
            UpdateTrianglePlaneMesh();
        }
    }

    void CalculateTetrahedron()
    {
        // Calculate tetrahedron vertices based on the updated triangle plane
        Vector3 center = (baseTriangleVertices[0] + baseTriangleVertices[1] + baseTriangleVertices[2]) / 3f;
        Vector3 topVertex = new Vector3(center.x, center.y, center.z + 1f); // Adjust height as needed

        tetrahedronVertices = new Vector3[]
        {
            baseTriangleVertices[0],
            baseTriangleVertices[1],
            baseTriangleVertices[2],
            topVertex
        };

        // Define tetrahedron triangles
        tetrahedronTriangles = new int[]
        {
            0, 1, 2, // Base triangle
            0, 1, 3, // Triangle ABD
            1, 2, 3, // Triangle BCD
            2, 0, 3  // Triangle CAD
        };
    }

    void UpdateTrianglePlaneMesh()
    {
        MeshFilter meshFilter = trianglePlane.GetComponent<MeshFilter>();
        if (meshFilter == null)
            return;

        Mesh mesh = new Mesh();
        mesh.vertices = baseTriangleVertices;
        mesh.triangles = new int[] { 0, 1, 2 };
        meshFilter.mesh = mesh;
    }

    void UpdateTetrahedronMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
            meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        mesh.vertices = tetrahedronVertices;
        mesh.triangles = tetrahedronTriangles;
        meshFilter.mesh = mesh;
    }
}


