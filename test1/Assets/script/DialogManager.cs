using System.Collections; // Required for IEnumerator
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject diag1; // Assign this in the Inspector
    public GameObject diag2; // Assign this in the Inspector

    void Start()
    {
        StartCoroutine(ShowDialogs());
    }

    IEnumerator ShowDialogs()
    {
        // Show diag1
        diag1.SetActive(true);
        print("hi");

        // Wait for diag1 to finish playing
        yield return new WaitForSeconds(4f); // Adjust the wait time as needed
        print("hii");
        // Hide diag1
        diag1.SetActive(false);

        // Wait for an additional 2 seconds
        yield return new WaitForSeconds(0.5f);
        print("hii");

        // Show diag2
        diag2.SetActive(true);

        // You can add additional code here if needed, such as waiting for diag2 to finish
    }
}

