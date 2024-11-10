using UnityEngine;

public class LineRendererDuplicator : MonoBehaviour
{
    public GameObject lineRendererParent; // The GameObject containing the Line Renderers
    public Vector3 newPosition; // The new position for the duplicated object

    void Start()
    {
        // Duplicate the Line Renderer GameObject
        GameObject duplicatedObject = Instantiate(lineRendererParent);

        // Move the duplicated object to the new position
        duplicatedObject.transform.position = newPosition;

        // Optionally, you can also set the name to distinguish it
        duplicatedObject.name = lineRendererParent.name + "_Copy";
    }
}
