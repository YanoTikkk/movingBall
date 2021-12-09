using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedRotation;
    
    private Rigidbody playerRigidbody;
    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    private void Mover()
    {
        Vector3 rotateForce = new Vector3(Input.GetAxis("Vertical") * speedRotation, 0f, -Input.GetAxis("Horizontal") * speedRotation);
        playerRigidbody.AddTorque(rotateForce);
    }
}
