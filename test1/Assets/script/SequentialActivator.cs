using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SequentialActivator : MonoBehaviour
{
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;

    public GameObject diag1;
    public GameObject diag2;

    private bool isdone = false;

    private void Start()
    {
        //print(a3.activeSelf);
        
    }

    private void Update()
    {
        if (r3.activeSelf && l3.activeSelf && !isdone)
        {
            print(r3.activeSelf);
            print(l3.activeSelf);
            StartCoroutine(ActivateDeactivateSequence());
        }
    }

    private IEnumerator ActivateDeactivateSequence()
    {
        diag1.SetActive(false); diag2.SetActive(true);

        for (int i = 0; i <= 2; i++)
        {
            r1.SetActive(true);
            r2.SetActive(false);
            r3.SetActive(false);

            l1.SetActive(true);
            l2.SetActive(false);
            l3.SetActive(false);

            yield return new WaitForSeconds(0.4f);

            // Deactivate a1, activate a2, and keep a3 deactivated
            r1.SetActive(false);
            r2.SetActive(true);
            r3.SetActive(false);

            l1.SetActive(false);
            l2.SetActive(true);
            l3.SetActive(false);

            yield return new WaitForSeconds(0.2f);

            // Activate a3, deactivate a2, and keep a1 deactivated
            r1.SetActive(false);
            r2.SetActive(false);
            r3.SetActive(true);

            l1.SetActive(false);
            l2.SetActive(false);
            l3.SetActive(true);
        }

        isdone = true;

        // Optional: Wait a bit before ending
        //yield return new WaitForSeconds(0.2f);
    }
}
