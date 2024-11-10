using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rectLine : MonoBehaviour
{
    public List<GameObject> cubes; // List of cubes (ensure this contains pairs of cubes)
    public GameObject lineRendererPrefab; // Prefab of the LineRenderer

    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    void Start()
    {
        // Ensure cubes list is valid and has even number of elements
        if (cubes.Count % 2 != 0)
        {
            Debug.LogError("Cubes list should contain pairs of cubes.");
            return;
        }

        // Process each pair of cubes
        //for (int i = 0; i < cubes.Count; i += 2)
        //{
        //    CreateConnection(cubes[i], cubes[i + 1]);
        //}
        for (int i = 0; i < cubes.Count; i++)
        {
            for (int j = i + 1; j < cubes.Count; j++)
            {
                GameObject firstElement = cubes[i];
                GameObject secondElement = cubes[j];
                CreateConnection(firstElement, secondElement);
            }
        }
    }

    void CreateConnection(GameObject cube1, GameObject cube2)
    {
        // Instantiate a LineRenderer from prefab
        GameObject lineRendererObject = Instantiate(lineRendererPrefab);
        LineRenderer lineRenderer = lineRendererObject.GetComponent<LineRenderer>();

        // Set positions of LineRenderer
        lineRenderer.SetPosition(0, cube1.transform.position);
        lineRenderer.SetPosition(1, cube2.transform.position);

        // Update positions in every frame to maintain connection
        StartCoroutine(UpdateLineRendererPosition(lineRenderer, cube1.transform, cube2.transform));

        // Add LineRenderer to the list
        lineRenderers.Add(lineRenderer);
    }

    System.Collections.IEnumerator UpdateLineRendererPosition(LineRenderer lineRenderer, Transform cube1, Transform cube2)
    {
        while (true)
        {
            lineRenderer.SetPosition(0, cube1.position);
            lineRenderer.SetPosition(1, cube2.position);
            yield return null; // Wait until the next frame
        }
    }

    //void UpdateLineRendererPositions()
    //{
    //Vector3 cubePosition = transform.position;
    //1, 2
    //lineRenderers.SetPosition(0, cubes[0].transform.position);
    //lineRenderers.SetPosition(1, cubes[1].transform.position);

    //1, 3
    //lineRenderers.SetPosition(0, cubes[0].transform.position);
    //lineRenderers.SetPosition(1, cubes[2].transform.position);

    //}
}
