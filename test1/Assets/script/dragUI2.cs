using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class dragUI2 : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform dragRectTransform;
    public Canvas canvas;
    private Vector2 offset;
    public float xMin;
    public float xMax;
    bool ismove = false;
    Vector2 startPos;
    Vector2 rectPos;
    void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(dragRectTransform, eventData.position, eventData.pressEventCamera, out offset);
        //offset = dragRectTransform.anchoredPosition - offset;

        ismove = true;
        startPos = Input.mousePosition;
        rectPos = dragRectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ismove)
        {
            offset = (Vector2)Input.mousePosition - startPos;
            float theX = rectPos .x+ offset.x;
            theX = Mathf.Clamp(theX, xMin, xMax);
            dragRectTransform.anchoredPosition = new Vector2(theX, -10);
            //Debug.Log(offset.x+"---"+theX);
        }
        //if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 globalMousePos))
        //{
        //    dragRectTransform.anchoredPosition = globalMousePos + offset;
        //    float theX = dragRectTransform.anchoredPosition.x;
        //    theX = Mathf.Clamp(theX, xMin, xMax);
        //    print(theX);
        //    dragRectTransform.anchoredPosition = new Vector2(theX, -10);
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ismove = false;
    }


}
