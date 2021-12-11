using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedRotation;
    [SerializeField] private Transform cameraCenter;
    
    private Rigidbody playerRigidbody;
    private CoinsManager coinsManager;
    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.maxAngularVelocity = 15f;
        coinsManager = FindObjectOfType<CoinsManager>().GetComponent<CoinsManager>();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up,ForceMode.Impulse);
        }
    }

    private void Mover()
    {
        playerRigidbody.AddTorque(cameraCenter.right * Input.GetAxis("Vertical") * speedRotation);
        playerRigidbody.AddTorque(cameraCenter.forward * -Input.GetAxis("Horizontal") * speedRotation);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>() != null)
        {
            coinsManager.ColectCoins(other.GetComponent<Coin>());
        }
    }
}
