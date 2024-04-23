using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float yawLimit = 50; // how far we can go left/right
    [SerializeField] float pitchLimit = 30; // how far we can go up/down

    Vector3 rotation = Vector3.zero;
    Vector2 prevAxis = Vector2.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        prevAxis.x = -Input.GetAxis("Mouse Y");
        prevAxis.y = Input.GetAxis("Mouse X");
    }

    void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.x = -Input.GetAxis("Mouse Y") - prevAxis.x; // gotta invert it 
        axis.y = Input.GetAxis("Mouse X") - prevAxis.y;


        rotation.x += axis.x * speed;
        rotation.y += axis.y * speed;

        rotation.x = Mathf.Clamp(rotation.x, -pitchLimit, pitchLimit);
        rotation.y = Mathf.Clamp(rotation.y, -yawLimit, yawLimit);

        Quaternion qYaw = Quaternion.AngleAxis(rotation.y, Vector3.up); 
        Quaternion qPitch = Quaternion.AngleAxis(rotation.x, Vector3.right); 

        transform.localRotation = qYaw * qPitch;
    }
}
