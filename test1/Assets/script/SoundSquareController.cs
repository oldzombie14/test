using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    public AudioClip soundToPlay;
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundToPlay;
        // Ensure the sound doesn't play at start
        audioSource.playOnAwake = false;
    }

    void OnMouseDown()
    {
        //Debug.Log("Mouse Down");
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        isDragging = true;
        audioSource.Play();
    }

    void OnMouseUp()
    {
        //Debug.Log("Mouse Up");
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
             Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
             Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
             transform.position = newPosition;
        }
        
        //if (Input.GetKeyDown(KeyCode.A))
        //{
            // Play the sound
        //    audioSource.Play();
        //}
    }
}

