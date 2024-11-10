using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDragUI : MonoBehaviour, IPointerDownHandler, IDragHandler
{ 
    private RectTransform dragRectTransform;
    private Canvas canvas;
    private Vector2 offset;

    void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();  // 确保获取到最上层的Canvas
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dragRectTransform, eventData.position, eventData.pressEventCamera, out offset);
        offset = dragRectTransform.anchoredPosition - offset;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 globalMousePos))
        {
            dragRectTransform.anchoredPosition = globalMousePos + offset;
            dragRectTransform.anchoredPosition = new Vector2(dragRectTransform.anchoredPosition.x,0);
        }
    }
}


