using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform muzzle; //where we shootin from goobus
    [SerializeField] AudioSource audioSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            audioSource.Play();
            Instantiate(ammo, muzzle.position, muzzle.rotation);
        }
    }
}
