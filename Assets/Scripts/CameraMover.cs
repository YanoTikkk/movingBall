using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;

    private List<Vector3> vectorTreesList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            vectorTreesList.Add(Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        vectorTreesList.Add(playerRigidbody.velocity);
        vectorTreesList.RemoveAt(0);
    }

    private void Update()
    {
        cameraMover();
    }

    private void cameraMover()
    {
        Vector3 summ = Vector3.zero;

        for (int i = 0; i < vectorTreesList.Count; i++)
        {
            summ = vectorTreesList[i];
        }
        
        transform.position = playerTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ),Time.deltaTime * 5f);
    }
}
