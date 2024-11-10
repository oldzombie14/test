using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Eq; // The specific game object used for even flips
    public List<GameObject> tarChildList; // List of game objects for odd flips
    public List<GameObject> Dialogues;
    //public GameObject cube;
    public Transform cameraTransform;
    private Vector3 velocity = Vector3.zero;

    private int flipCount = 0; // Tracks the number of card flips
    private int round = 0;
    private int eqCount = 0;
    private int indAssist = 0;
    public GameObject currentTar; // Field to store the current tar

    void Start()
    {
        
    }

    // Call this method whenever a card is flipped
    public void OnCardFlip()
    {
        flipCount++; // Increment the flip count
        //print(flipCount);

        StartCoroutine(Dialog());

        if (flipCount % 9 == 0 && round<3)
        {
            StartCoroutine(MoveCamera());
            round++;
        }

        if ((flipCount + 1) % 3 == 0 && eqCount<12)
        {
            currentTar = Eq;
            eqCount++;
        }
        else
        {   
            indAssist++;
            int index = (indAssist - 1);
            if (index < tarChildList.Count)
            {
                currentTar = tarChildList[index];
            }
            else
            {
                Debug.LogWarning("Flip count exceeds the tarChildList length.");
                return;
            }
        }

        // Use currentTar for further processing
        Debug.Log($"Selected tarChild: {currentTar.name}");

        // Implement your logic here, e.g., update UI, manipulate game objects, etc.
    }

    // Public method to get the current tar
    public GameObject GetCurrentTar()
    {
        //print("received");
        return currentTar;
    }

    IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(1f);
        Vector3 startPosition = cameraTransform.position;
        Vector3 targetPosition = startPosition + new Vector3(130f, 0, 0);

        float timeElapsed = 0f;

        while (timeElapsed < 3f)
        {
            timeElapsed += Time.deltaTime;
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetPosition, ref velocity, 0.9f);
            yield return null; // Wait for the next frame
        }

        // Ensure the camera is exactly at the target position
        cameraTransform.position = targetPosition;
    }

    IEnumerator Dialog()
    {
        if (flipCount > 0 && flipCount <3)
        {
            Dialogues[0].SetActive(true);
            yield return new WaitForSeconds(3f);
            Dialogues[0].SetActive(false);
        }
        if(flipCount == 3)
        {
            Dialogues[1].SetActive(true);
            yield return new WaitForSeconds(4f);
            Dialogues[1].SetActive(false);
        }
        if (flipCount == 4)
        {
            Dialogues[2].SetActive(true);
            yield return new WaitForSeconds(3f);
            Dialogues[2].SetActive(false);
        }

        if (flipCount == 9)
        {
            yield return new WaitForSeconds(3f);
            Dialogues[3].SetActive(true);
            yield return new WaitForSeconds(6f);
            Dialogues[3].SetActive(false);
        }


        yield return null;
    }

}
