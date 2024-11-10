using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
    public float swingForce = 5f; // Force applied on click
    public float damping = 0.95f; // Damping factor to slow down swinging

    private Rigidbody rb;
    private bool isSwinging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock rotation to prevent the sphere from rolling over
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Apply a force to swing the pendulum
            Vector3 forceDirection = Vector3.right; // Adjust this to change the swing direction
            rb.AddForce(forceDirection * swingForce, ForceMode.Impulse);
            isSwinging = true; // Start swinging
        }

        // Gradually reduce the swing if not clicking
        if (isSwinging)
        {
            rb.velocity *= damping; // Dampen the swing

            // Stop swinging if the velocity is very low
            if (rb.velocity.magnitude < 0.1f)
            {
                isSwinging = false; // Stop swinging when velocity is low
                rb.velocity = Vector3.zero; // Stop any remaining movement
            }
        }
    }
}
