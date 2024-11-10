using UnityEngine;

public class CController : MonoBehaviour
{
    public Transform c0;
    public Transform c1, c2, c3, c4, c5, c6, c7, c8;
    public float hmove;
    public float imove;
    public float vmove;
    public float scalef;

    private Vector3 originalDimensions;
    private float originalVolume;

    void Start()
    {
        // Calculate the original dimensions and volume
        originalDimensions = new Vector3(
            Vector3.Distance(c1.position, c2.position),  // width
            Vector3.Distance(c1.position, c5.position),  // height
            Vector3.Distance(c1.position, c4.position)   // depth
        );
        originalVolume = 3*originalDimensions.x * originalDimensions.y * originalDimensions.z;
    }

    void Update()
    {
        AdjustRectangularShape();
    }

    void AdjustRectangularShape()
    {
        // Get the Y position of the controller cube
        float c0Y = c0.position.y;

        // Calculate new height based on the y position of c0
        float newHeight = originalDimensions.y * (1 + (c0Y - transform.position.y)*scalef);
        float currentVolume = originalVolume;

        // Calculate new width and depth to maintain the same volume
        float newWidth = Mathf.Sqrt(currentVolume / newHeight);
        float newDepth = newWidth;

        // Update the positions of cubes
        UpdateCubePositions(newWidth, newHeight, newDepth);
    }

    void UpdateCubePositions(float width, float height, float depth)
    {
        // Example logic to update cube positions, needs to be adjusted based on your setup
        c1.position = new Vector3(-width / 2-hmove, 0 - vmove, -depth / 2 - imove);
        c2.position = new Vector3(width / 2 - hmove, 0 - vmove, -depth / 2 - imove);
        c3.position = new Vector3(width / 2 - hmove, 0 - vmove, depth / 2 - imove);
        c4.position = new Vector3(-width / 2 - hmove, 0 - vmove, depth / 2 - imove);
        c5.position = new Vector3(-width / 2 - hmove, height - vmove, -depth / 2 - imove);
        c6.position = new Vector3(width / 2 - hmove, height - vmove, -depth / 2 - imove);
        c7.position = new Vector3(width / 2 - hmove, height - vmove, depth / 2 - imove);
        c8.position = new Vector3(-width / 2 - hmove, height - vmove, depth / 2 - imove);
    }
}
