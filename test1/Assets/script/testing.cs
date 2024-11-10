using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  // 引入处理UI事件所需的命名空间

public class DragUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    public float xMin;
    public float xMax;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindInParents<Canvas>(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 将鼠标的屏幕位置转换为与Canvas相关的世界位置
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out Vector3 globalMousePos);
        //rectTransform.position = globalMousePos;
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rectTransform.position = globalMousePos + offset;
    }

    public void OnDrag(PointerEventData eventData)
    {
     
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out Vector3 globalMousePos))
        {
            
            rectTransform.position = globalMousePos;
            float theX;

            theX = rectTransform.position.x;

            theX = Mathf.Clamp(theX,xMin,xMax);

            rectTransform.position = new Vector3(
            theX,
            550,
            0
            );
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