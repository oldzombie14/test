using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleToHalf : MonoBehaviour
{
    public GameObject bigCircle;
    public GameObject halfCircle1; // Left half circle
    public GameObject halfCircle2; // Right half circle
    public GameObject smallCircle1; // Small circle for left half
    public GameObject smallCircle2; // Small circle for right half
    public GameObject equal;

    private enum State
    {
        BigCircle,
        HalfCircles,
        SmallCircles
    }

    private State currentState = State.BigCircle;

    void OnMouseDown()
    {
        print(currentState);
        switch (currentState)
        {
            case State.BigCircle:
                bigCircle.SetActive(true);
                equal.SetActive(false);
                //print("begin");
                TransitionToHalfCircles();
                break;

            case State.HalfCircles:
                //print("hi");
                TransitionToSmallCircles();
                break;

            case State.SmallCircles:
                //print("hello");
                // Optional: You can add functionality for when clicking on small circles if needed.
                break;
        }
    }

    private void TransitionToHalfCircles()
    {
        bigCircle.SetActive(false);

        halfCircle1.SetActive(true);
        halfCircle2.SetActive(true);

        Vector3 originalPosition = transform.position;
        halfCircle1.transform.position = originalPosition + new Vector3(-3f, -0.5f, 0);
        halfCircle2.transform.position = originalPosition + new Vector3(3f, -0.5f, 0);

        currentState = State.HalfCircles;
    }

    private void TransitionToSmallCircles()
    {
        halfCircle1.SetActive(false);
        halfCircle2.SetActive(false);

        smallCircle1.SetActive(true);
        smallCircle2.SetActive(true);

        Vector3 halfCircle1Position = halfCircle1.transform.position;
        Vector3 halfCircle2Position = halfCircle2.transform.position;

        smallCircle1.transform.position = halfCircle1Position + new Vector3(-0.2f, -0.2f, 0);
        smallCircle2.transform.position = halfCircle2Position + new Vector3(0.2f, -0.2f, 0);

        currentState = State.SmallCircles;
    }

}
