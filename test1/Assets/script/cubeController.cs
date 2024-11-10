using UnityEngine;

public class CubeController : MonoBehaviour
{
    private int spheresLanded = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            spheresLanded++;
            if (spheresLanded == 5)  // Assuming you have 5 spheres
            {
                Debug.Log("All spheres have landed on the cube!");
                // Perform any action when all spheres have landed
            }
        }
    }
}

