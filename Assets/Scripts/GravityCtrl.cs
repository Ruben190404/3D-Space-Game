using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    public Gravity Gravity;
    private Rigidbody _rb;

    public float RotationSpeed = 20;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (Gravity)
        {
            Vector3 gravityUp = Vector3.zero;
            
            gravityUp = (transform.position - Gravity.transform.position).normalized;
            
            Vector3 localUp = transform.up;
            
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            
            transform.up = Vector3.Lerp(transform.up, gravityUp, RotationSpeed * Time.deltaTime);
            
            _rb.AddForce(-gravityUp * (Gravity._gravity * _rb.mass));
        }
    }
}
