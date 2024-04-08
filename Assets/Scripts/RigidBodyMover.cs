using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMover : MonoBehaviour
{
    [SerializeField] Vector3 force; // 'linear' force
    [SerializeField] ForceMode mode;

    [SerializeField] Vector3 torque; // angular force
    [SerializeField] ForceMode torqueMode;

    [SerializeField] KeyCode jumpKey;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(jumpKey))
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse); // impulse is instantanious
        }
    }

    private void FixedUpdate() // called more regularly than Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(force, mode); //relative force takes orientation into account
            rb.AddTorque(torque, torqueMode);
        }
    }
}
