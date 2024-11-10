using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;

public class SoundSphereController : MonoBehaviour
{
    public GameObject plane1;     // Public variable for main plane
    public GameObject sidePlane1; // Public variable for side plane 1
    public GameObject sidePlane2; // Public variable for side plane 2
    public GameObject[] bowls;
    public GameObject[] TriggerCubes;

    public float magnitude = 3f;
    public float decayRate = 1f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool onBowl;
    private AudioSource audioSource;
    private bool isDragging = false;
    private Vector3 offset;
    private float cnt = 0;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -60.0f, 0);
        isGrounded = false;
        audioSource = GetComponent<AudioSource>();
        //audioSource.playOnAwake = false;
        audioSource.Stop();
    }

    void OnMouseDown()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
        //offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = gameObject.transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void OnMouseDrag()
    {
        //print("hi");
        // Convert mouse position to world position
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Update object position
        //transform.position = new Vector3(objPosition.x, transform.position.y, objPosition.z);
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        //newPosition.z = 0;
        transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in screen space.
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen space to world space.
        mousePosition.z = Camera.main.nearClipPlane; // Adjust this if your camera's near clip plane is not at z=0
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void Update()
    {
        //print(GetMouseWorldPosition());
        if (isGrounded)
        {
            // Apply a small torque to make the sphere roll
            while (magnitude > 0){
                rb.AddTorque(Vector3.back * magnitude, ForceMode.Impulse);
                magnitude -= decayRate * Time.deltaTime;
                //yield return null;
            }
        }

        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        }
   
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the sphere has collided with the main plane
        if (collision.gameObject == plane1)
        {
            isGrounded = true;
            if (cnt<1)
            {
                cnt+=1;
                audioSource.Play();
            }
        }

        if (bowls.Contains(collision.gameObject)||(TriggerCubes.Contains(collision.gameObject)))
        {
            onBowl = true;
            while (magnitude > 0)
            {
            rb.AddTorque(Vector3.back * magnitude, ForceMode.Impulse);
            magnitude -= 4f * Time.deltaTime;
            }
        }

        // Additional logic for side planes (if needed)
        if (collision.gameObject == sidePlane1 || collision.gameObject == sidePlane2)
        {
            // Handle collision with side planes if needed
        }
    }
}


