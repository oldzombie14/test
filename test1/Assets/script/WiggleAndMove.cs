using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleAndMove : MonoBehaviour
{
    public float wiggleAmount = 0.5f;
    public float wiggleDuration = 0.5f;
    public float moveDownDistance = 5f;
    public float moveDownDuration = 1f;

    private Vector3 originalPosition;
    private bool isMoving = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            StartCoroutine(WiggleAndMoveDown());
        }
    }

    IEnumerator WiggleAndMoveDown()
    {
        isMoving = true;
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + Vector3.down * moveDownDistance;

        while (elapsedTime < wiggleDuration)
        {
            float wiggleX = Mathf.Sin(Time.time * 20) * wiggleAmount;
            float wiggleY = Mathf.Sin(Time.time * 30) * wiggleAmount;
            transform.position = new Vector3(startPos.x + wiggleX, startPos.y + wiggleY, startPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < moveDownDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / moveDownDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
        yield return null;
    }
}

