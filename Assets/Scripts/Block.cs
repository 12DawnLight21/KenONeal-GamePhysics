using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    [SerializeField] int points = 10;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TextMeshProUGUI text;

    Rigidbody rb;
    bool destroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2)
        { 
            audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!destroyed && 
            other.CompareTag("Kill") && 
            rb.velocity.magnitude == 0 && 
            rb.angularVelocity.magnitude == 0) //checks tags and also checks if its stop
        {
            destroyed = true;
            print(points);
            Destroy(gameObject, 2);
        }
    }

    public int GetPoints()
    {
        return points;
    }

}
