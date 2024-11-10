using UnityEngine;

public class CController2 : MonoBehaviour
{
    public Transform c0;
    public Transform[] cubes; // Assign cubes in order as specified

    private float initialWidth;
    private float initialHeight;
    private float initialLength;
    private float initialVolume;

    void Start()
    {
        if (cubes.Length != 8)
        {
            Debug.LogError("Please assign exactly 8 cubes to the array.");
            return;
        }

        // Calculate initial width, height, and volume
        initialWidth = Vector3.Distance(cubes[0].position, cubes[1].position); // Bottom row width
        initialHeight = Vector3.Distance(cubes[4].position, cubes[0].position); // Height from bottom to top
        initialLength = Vector3.Distance(cubes[0].position, cubes[2].position);
        initialVolume = (initialWidth * initialLength * initialHeight)/20; // Assuming cubes are square-based
    }

    void Update()
    {
        AdjustCubes();
    }

    void AdjustCubes()
    {
        float c0Y = c0.position.y;
        float height = Mathf.Clamp(c0Y, 0f, 100f); // Clamp as needed
        float width = Mathf.Sqrt(initialVolume / height);

        // Update the top row positions
        cubes[4].position = new Vector3(cubes[4].position.x - width / 2, height, cubes[4].position.z); // Upper-inner left
        cubes[5].position = new Vector3(cubes[5].position.x - width / 2, height, cubes[5].position.z); // Upper-outer left
        cubes[6].position = new Vector3(cubes[6].position.x + width / 2, height, cubes[6].position.z); // Upper-inner right
        cubes[7].position = new Vector3(cubes[7].position.x + width / 2, height, cubes[7].position.z); // Upper-outer right

        // Update the width of the bottom row cubes
        Vector3 bottomLeftInner = cubes[0].position; // Bottom-inner left
        Vector3 bottomLeftOuter = cubes[1].position; // Bottom-outer left
        Vector3 bottomRightInner = cubes[2].position; // Bottom-inner right
        Vector3 bottomRightOuter = cubes[3].position; // Bottom-outer right

        // Move bottom row cubes horizontally
        cubes[0].position = new Vector3(bottomLeftInner.x - width / 2, cubes[0].position.y, bottomLeftInner.z);
        cubes[1].position = new Vector3(bottomLeftInner.x - width / 2, cubes[1].position.y, bottomLeftOuter.z);
        cubes[2].position = new Vector3(bottomRightInner.x + width / 2, cubes[2].position.y, bottomRightInner.z);
        cubes[3].position = new Vector3(bottomRightInner.x + width / 2, cubes[3].position.y, bottomRightOuter.z);
    }
}

