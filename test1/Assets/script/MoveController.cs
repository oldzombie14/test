using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject targetCamera; // Reference to the Camera
    public GameObject[] gameObjectsToMove; // Array of game objects to move

    private ballCheck ballCheck; // Reference to Script1

    void Start()
    {
        // Find the GameObject that has Script1 attached to it
        ballCheck = FindObjectOfType<ballCheck>();
    }

    void Update()
    {
        // Check if the public variable is true
        if (ballCheck != null && ballCheck.anyCircleMoved)
        {
            MoveCameraAndObjects();
        }
    }

    void MoveCameraAndObjects()
    {
        // Move the camera to the target position
        targetCamera.transform.position = new Vector3(0, 10, -10); // Replace with your target position

        // Move the other game objects
        foreach (GameObject obj in gameObjectsToMove)
        {
            obj.transform.position += new Vector3(1, 0, 0); // Example movement, replace with your logic
        }
    }
}
