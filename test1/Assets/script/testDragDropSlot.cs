using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class testDragDropSlot : MonoBehaviour, IDropHandler
{
    public bool ifmatch = false;
    //public string targetObjectName;
    public GameObject targetObject;
    public List<GameObject> poles;
    public bool isPole;
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            GameObject draggedObject = eventData.pointerDrag;

            if ((isPole != true) && (draggedObject.name == targetObject.name))
            {
                ifmatch = true;
                Debug.Log("non-pole Match!");
            }
            else if (isPole == true)
            {
                if (poles.Contains(draggedObject))
                {
                    ifmatch = true;
                    Debug.Log("pole Match!");
                }
            }
            draggedObject.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
