using System.Collections; // Required for IEnumerator
using UnityEngine;
using UnityEngine.UI;

public class DialogManagerTetra : MonoBehaviour
{
    public GameObject diag1; // Assign this in the Inspector
    public GameObject diag2; // Assign this in the Inspector
    public GameObject earth;
    public GameObject earthRect;

    void Start()
    {
        earth.SetActive(false);
        earthRect.SetActive(false);
        StartCoroutine(ShowDialogs());
    }

    IEnumerator ShowDialogs()
    {
        // Show diag1
        diag1.SetActive(true);

        // Wait for diag1 to finish playing
        yield return new WaitForSeconds(8f); // Adjust the wait time as needed

        // Hide diag1
        diag1.SetActive(false);

        // Wait for an additional 2 seconds
        yield return new WaitForSeconds(1f);

        // Show diag2
        diag2.SetActive(true);
        yield return new WaitForSeconds(1f);
        OnDialogueEnd();
        // You can add additional code here if needed, such as waiting for diag2 to finish
    }

    public void OnDialogueEnd()
    {
        earth.SetActive(true);
        earthRect.SetActive(true);
    }
}

