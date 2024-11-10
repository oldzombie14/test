using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleSpin : MonoBehaviour
{
    public float spinSpeed = 500.0f;       // Speed at which the object spins
    public float momentumDecay = 0.99f;    // Rate at which momentum decays

    private float currentSpeed = 0.0f;     // Current spin speed
    private bool isSpinning = false;       // Flag to track if spinning

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpinning = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpinning = false;
        }

        if (isSpinning)
        {
            currentSpeed += spinSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed *= momentumDecay;
        }

        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);

        // If speed is very low, stop spinning to prevent jitter
        if (Mathf.Abs(currentSpeed) < 0.1f)
        {
            currentSpeed = 0.0f;
        }
    }
}
