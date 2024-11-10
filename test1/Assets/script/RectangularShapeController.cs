using UnityEngine;

public class RectangularShapeController : MonoBehaviour
{
    public Transform c0;
    public Transform[] surroundingCubes;

    public float initialWidth = 1f; 
    public float initialHeight = 0.5f;
    public float initialDepth = 1f; 

    private float volume;

    void Start()
    {
        volume = initialWidth * initialHeight * initialDepth;
    }

    void Update()
    {
        float newHeight = Mathf.Clamp(c0.position.y, 0.12f, 3f);

        float newWidth = volume / (newHeight * initialDepth);

        UpdateCubes(newWidth, newHeight);
    }

    void UpdateCubes(float newWidth, float newHeight)
    {
        float halfWidth = newWidth+0.3f/ 2;
        float halfHeight = newHeight/ 2;
        float depth = initialDepth;

        if (surroundingCubes.Length >= 8)
        {
            surroundingCubes[0].localPosition = new Vector3(-halfWidth - 4.5f, -halfHeight - 2.5f, 5);
            surroundingCubes[1].localPosition = new Vector3(-halfWidth - 4.5f, -halfHeight - 2.5f, 3);
            surroundingCubes[2].localPosition = new Vector3(halfWidth - 4.5f, -halfHeight - 2.5f, 5);
            surroundingCubes[3].localPosition = new Vector3(halfWidth - 4.5f, -halfHeight - 2.5f, 3);

            surroundingCubes[4].localPosition = new Vector3(-halfWidth - 4.5f, halfHeight + depth- 1f, 5);
            surroundingCubes[5].localPosition = new Vector3(-halfWidth - 4.5f, halfHeight + depth - 1f, 3);
            surroundingCubes[6].localPosition = new Vector3(halfWidth - 4.5f, halfHeight + depth - 1f, 5);
            surroundingCubes[7].localPosition = new Vector3(halfWidth - 4.5f, halfHeight + depth - 1f, 3);
        }
    }
}
