using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    public float speed = 1.5f;
    public float limit = 75f;
    public bool randomStart = false;
    private float random = 0;

    private HingeJoint hingeJoint;
    public float angularForce = 10f; // Force to apply on click

    void Awake()
    {
        if (randomStart)
            random = Random.Range(0f, 1f);

        // Get the HingeJoint component
        hingeJoint = GetComponent<HingeJoint>();
    }

    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time + random * speed);
        transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(angle, -limit, limit));
    }

    private void OnMouseDown()
    {
        // Add angular force when the pendulum is clicked
        if (hingeJoint != null)
        {
            Rigidbody rb = hingeJoint.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddTorque(Vector3.forward * angularForce, ForceMode.Impulse);
                rb.angularVelocity = Vector3.zero; // Optionally reset angular velocity
            }
        }
    }

}
