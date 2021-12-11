using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private CoinsManager coinsManager;
    private Coin closesCoin;

    private void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>().GetComponent<CoinsManager>();
    }

    private void Update()
    {
        closesCoin = coinsManager.GetCloses(transform.position);
        transform.LookAt(closesCoin.transform.position);
    }
}
