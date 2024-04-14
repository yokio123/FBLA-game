using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System;
public class PlayerPosition : MonoBehaviour
{

    
    private Vector3 offset = new Vector3(0f, 0.5f, -10f);

    
    public Transform target;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = targetPosition;
    }
}
