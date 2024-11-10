using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    public GameObject square;
    public GameObject circle;
    public GameObject[] secondaryShapes; // Small rectangle, triangle, oval

    private int currentShapeIndex = 0; // Index of current secondary shape

    private bool isRotating = false;

    void Update()
    {
        // Check for spacebar press to rotate square and circle
        if (Input.GetKey(KeyCode.Space) && !isRotating)
        {
            StartCoroutine(SwitchObjectsCoroutine());
        }

        // Check for mouse click to switch secondary shape
        if (Input.GetMouseButtonDown(0))
        {
            SwitchToNextShape();
        }
    }

    IEnumerator SwitchObjectsCoroutine()
    {
        isRotating = true;

        // Determine the rotation center
        Vector3 rotationCenter = transform.position;

        // Determine the rotation parameters
        float angleToRotate = 90f; // 90 degrees clockwise rotation
        float duration = 0.35f; // Duration of rotation in seconds

        float currentAngle = 0f;
        float startTime = Time.time;

        // Rotate around RotationCenter until reaching angleToRotate
        while (currentAngle < angleToRotate)
        {
            float t = (Time.time - startTime) / duration;
            currentAngle = Mathf.Lerp(0, angleToRotate, t);

            // Rotate square
            square.transform.RotateAround(rotationCenter, Vector3.forward, angleToRotate * Time.deltaTime / duration);

            // Rotate circle
            circle.transform.RotateAround(rotationCenter, Vector3.forward, angleToRotate * Time.deltaTime / duration);

            yield return null;
        }

        // Swap positions after rotation completes
        Vector3 tempPos = square.transform.position;
        square.transform.position = circle.transform.position;
        circle.transform.position = tempPos;

        isRotating = false;
    }

    void SwitchToNextShape()
    {
        currentShapeIndex = (currentShapeIndex + 1) % secondaryShapes.Length;
        Vector3 midpoint = (square.transform.position + circle.transform.position) / 2f;
        secondaryShapes[currentShapeIndex].transform.position = midpoint;

        // Activate the selected shape and deactivate others
        for (int i = 0; i < secondaryShapes.Length; i++)
        {
            secondaryShapes[i].SetActive(i == currentShapeIndex);
        }
    }
}