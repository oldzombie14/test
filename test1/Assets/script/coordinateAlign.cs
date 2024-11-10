using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class coordinateAlign : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    public LineRenderer lineRenderer3;
    public LineRenderer lineRenderer4;

    public GameObject imageToScale;
    public GameObject imageToScale_child;
    public float scaleMultiplier = 0.0000001f;
    private float initialY;

    public float minY = 0f;
    public float maxY = 5f;


    void Start()
    {
        initialY = transform.position.y;
        Color color = imageToScale_child.GetComponent<SpriteRenderer>().color;
        color.a = 0f;
        imageToScale_child.GetComponent<SpriteRenderer>().color = color;
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        //offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.y, 10.0f));
        isDragging = true;
    }

    void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);

            Vector3 mousePosition = new Vector3(0.0f, mousePos.y, 10.0f);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
            //transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
            transform.position = new Vector3(transform.position.x, newPosition.y, transform.position.z);

            // Update the Line Renderer's positions accordingly
            UpdateLineRendererPositions();
        }

        float yOffset = transform.position.y - initialY;
        float scaleValue = 1 + (yOffset * scaleMultiplier);
        print(scaleValue);
        if (imageToScale != null)
        {
            imageToScale.transform.localScale = new Vector3(scaleValue, scaleValue, 1);
            //imageToScale.transform.position = new Vector3(0, 0, 0);
            Color color = imageToScale_child.GetComponent<SpriteRenderer>().color;
            color.a = Mathf.Clamp01(yOffset * scaleMultiplier * 1.8f);
            imageToScale_child.GetComponent<SpriteRenderer>().color = color;
        }
    }

    void UpdateLineRendererPositions()
    {
        // Set the end positions of all line renderers to match the cube's current position
        Vector3 cubePosition = transform.position;
        //lineRenderer1.SetPosition(1, cubePosition + Vector3.up);
        lineRenderer1.SetPosition(1, cubePosition);
        lineRenderer2.SetPosition(1, cubePosition);
        lineRenderer3.SetPosition(1, cubePosition);
        lineRenderer4.SetPosition(1, cubePosition);
    }
}
