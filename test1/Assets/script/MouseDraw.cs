using System.Collections.Generic;
using UnityEngine;

public class MouseDraw : MonoBehaviour
{
    public GameObject targetObject; // Assign your target GameObject with the CircleCollider2D
    private LineRenderer lineRenderer;
    private int positionCount = 0;
    private CircleCollider2D circleCollider; // Reference to the CircleCollider2D on the target object
    public bool checkDraw = false; // Variable to check if a line has been drawn
    public List<GameObject> drawnLines = new List<GameObject>();

    void Start()
    {
        // Get the CircleCollider2D component attached to the target object
        circleCollider = targetObject.GetComponent<CircleCollider2D>();
        if (circleCollider == null)
        {
            Debug.LogError("CircleCollider2D not found on the target GameObject.");
        }
    }

    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            // Start a new line
            StartNewLine();
        }
        else if (Input.GetMouseButtonUp(0)) // When the button is released
        {
            // Optionally, reset the position count if needed for new lines
            positionCount = 0; // Reset position count
        }

        // Continue drawing if the mouse button is held down
        if (Input.GetMouseButton(0))
        {
            DrawLine();
        }
    }

    private void StartNewLine()
    {
        // Create a new GameObject for the new line
        GameObject newLine = new GameObject("Line");
        lineRenderer = newLine.AddComponent<LineRenderer>();

        // Optional: Set LineRenderer properties
        lineRenderer.startWidth = 0.7f; // Set start width
        lineRenderer.endWidth = 0.3f; // Set end width
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Assign material
        lineRenderer.positionCount = 0; // Initialize position count for this line

        //newLine.AddComponent<SpriteMask>(); // Add SpriteMask component to the line
        //newLine.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        positionCount = 0; // Reset position count for new line

        drawnLines.Add(newLine);
    }

    private void DrawLine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Check if the ray hits the target object
        if (hit.collider != null && hit.collider == circleCollider)
        {
            // Get the point in world space
            Vector3 hitPoint = hit.point;

            // Check if the hit point is inside the circle collider
            if (IsPointInsideCircleCollider(hitPoint))
            {
                // Set the position of the line
                lineRenderer.positionCount = positionCount + 1; // Increment position count
                lineRenderer.SetPosition(positionCount, hitPoint); // Set the position
                positionCount++; // Move to the next position

                // Set checkDraw to true since a line has been drawn
                checkDraw = true;
            }
        }
    }

    private bool IsPointInsideCircleCollider(Vector3 point)
    {
        // Get the radius and center of the CircleCollider2D
        float radius = circleCollider.radius * circleCollider.transform.localScale.x; // Scale the radius
        Vector2 center = (Vector2)circleCollider.transform.position + circleCollider.offset; // Get the center

        // Check if the distance from the center to the point is less than the radius
        return Vector2.Distance(center, point) <= radius;
    }

    public void ActivateAllLines()
    {
        foreach (var line in drawnLines)
        {
            line.SetActive(true);
        }
    }

    public void DeactivateAllLines()
    {
        foreach (var line in drawnLines)
        {
            line.SetActive(false);
        }
    }
}
