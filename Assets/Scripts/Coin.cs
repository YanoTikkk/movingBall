using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private void Update()
    {
        transform.Rotate(0f,speed * Time.deltaTime,0f);
    }
}
