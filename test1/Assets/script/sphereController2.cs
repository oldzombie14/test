using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject cube; // Public reference to the cube object
    private AudioSource audioSource;
    private bool hasPlayed = false;
    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); // Stop audio initially
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -60.0f, 0);
        isGrounded = false;
    }

    void Update()
    {
        if (isGrounded)
        {
            // Apply a small torque to make the sphere roll
            rb.AddTorque(Vector3.back * 3f, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == cube && !hasPlayed)
        {
            // Play audio clip
            isGrounded = true;
            audioSource.Play();
            hasPlayed = true;

            // Stop sphere from rolling further
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero; // Stop any movement
            rb.angularVelocity = Vector3.zero; // Stop any rotation
            rb.constraints = RigidbodyConstraints.FreezeAll; // Freeze position and rotation
        }
    }
}

