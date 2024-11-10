using UnityEngine;
using UnityEngine.EventSystems;

public class testing2 : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 offset; // Offset variable

    public float xMin;
    public float xMax;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindInParents<Canvas>(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localMousePos))
        {
            // Calculate offset
            offset = rectTransform.anchoredPosition - localMousePos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localMousePos))
        {
            // Apply offset
            rectTransform.anchoredPosition = localMousePos + (Vector2)offset;

            float theX = rectTransform.anchoredPosition.x;
            theX = Mathf.Clamp(theX, xMin, xMax);

            rectTransform.anchoredPosition = new Vector2(theX, -10);
           
        }
    }

    private T FindInParents<T>(GameObject gameObject) where T : Component
    {
        if (gameObject == null) return null;
        var comp = gameObject.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = gameObject.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}
