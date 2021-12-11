using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    
    private CoinsManager coinsManager;
    private Coin closesCoin;

    private void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>().GetComponent<CoinsManager>();
    }
    
    private void Update()
    {
        transform.position = playerPosition.position;
        RotateArrow();
    }

    private void RotateArrow()
    {
        closesCoin = coinsManager.GetCloses(transform.position);
        Vector3 toRotation = closesCoin.transform.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(toRotation),50f);
    }
}
