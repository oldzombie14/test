using UnityEngine;

public class DragCircle : MonoBehaviour
{
    public GameObject squareObject; // Assign your square object in the inspector
    private Vector3 offset;
    private bool isDragging = false;

    // Public boolean to track if the circle has moved
    public bool hasMoved = false;

    private void OnMouseDown()
    {
        // Start dragging
        isDragging = true;
        offset = Camera.main.WorldToScreenPoint(transform.localPosition) - Input.mousePosition;
    }

    private void OnMouseUp()
    {
        // Stop dragging
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            // Get mouse position and calculate new position
            Vector3 mousePosition = Input.mousePosition + offset;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0; // Ensure the z position is 0 if you're working in 2D

            // Check if the new position is within the square bounds
            if (IsWithinSquareBounds(mousePosition))
            {
                // Update position
                transform.localPosition = mousePosition;
                hasMoved = true; // Set hasMoved to true if the circle has moved
            }
        }
    }

    private bool IsWithinSquareBounds(Vector3 position)
    {
        // Get the square bounds
        BoxCollider2D squareCollider = squareObject.GetComponent<BoxCollider2D>();
        Vector2 squareSize = squareCollider.size;
        Vector2 squareCenter = squareObject.transform.position;

        // Calculate half extents
        float halfWidth = squareSize.x / 2;
        float halfHeight = squareSize.y / 2;

        // Check if the position is within the square
        return position.x >= -3.48f && position.x <= 0.6f &&
               position.y >= -1.8f && position.y <= 2.2f;
    }
}
