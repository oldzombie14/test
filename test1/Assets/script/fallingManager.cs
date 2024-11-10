using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] fallingObjects;
    public GameObject[] fallingObjects2;
    public float thresholdX = -3.4f;
    public float thresholdX2 = 3.4f;
    private Vector3[] initialPositions;
    private Vector3[] initialPositions2;

    void Start()
    {
        initialPositions = new Vector3[fallingObjects.Length];
        initialPositions2 = new Vector3[fallingObjects2.Length];

        for (int i = 0; i < fallingObjects.Length; i++)
        {
            initialPositions[i] = fallingObjects[i].transform.position;
        }

        foreach (GameObject obj in fallingObjects)
        {
            obj.SetActive(false);
        }

        for (int i = 0; i < fallingObjects2.Length; i++)
        {
            initialPositions2[i] = fallingObjects2[i].transform.position;
        }

        foreach (GameObject obj in fallingObjects2)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        print(ball.transform.position.x);
        if (ball.transform.position.x < thresholdX)
        {
            //print("111");
            StartCoroutine(ActivateAndFall());
        }

        if (ball.transform.position.x > thresholdX2)
        {
            //print("2");
            StartCoroutine(ActivateAndFall2());
        }
    }

    private IEnumerator ActivateAndFall()
    {
        // Activate and make each object fall with a 1 second delay
        foreach (GameObject obj in fallingObjects)
        {
            obj.SetActive(true);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }

            // Wait for 1 second before activating the next object
            yield return new WaitForSeconds(1f);
        }

        // Wait for 5 seconds to let the objects fall before resetting
        yield return new WaitForSeconds(2f);

        // Reset the objects after falling
        for (int i = 0; i < fallingObjects.Length; i++)
        {
            fallingObjects[i].transform.position = initialPositions[i];
            Rigidbody rb = fallingObjects[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            fallingObjects[i].SetActive(false);
        }
    }

    private IEnumerator ActivateAndFall2()
    {
        // Activate and make each object fall with a 1 second delay
        foreach (GameObject obj in fallingObjects2)
        {
            obj.SetActive(true);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }

            // Wait for 1 second before activating the next object
            yield return new WaitForSeconds(1f);
        }

        // Wait for 5 seconds to let the objects fall before resetting
        yield return new WaitForSeconds(2f);

        // Reset the objects after falling
        for (int i = 0; i < fallingObjects2.Length; i++)
        {
            fallingObjects2[i].transform.position = initialPositions2[i];
            Rigidbody rb = fallingObjects2[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            fallingObjects2[i].SetActive(false);
        }
    }
}
