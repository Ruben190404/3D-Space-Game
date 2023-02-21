using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    public float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, -10, _rb.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 10, _rb.velocity.z);
        }
    }

    
    void FixedUpdate()
    {
        //Draw line to gravity direction
        // Debug.DrawLine(transform.position, transform.position + transform.up * 10, Color.red);
        float _Hinput = Input.GetAxis("Horizontal");
        float _Vinput = Input.GetAxis("Vertical");
        Vector3 _movement = (transform.right * _Hinput + transform.forward * _Vinput) * _speed;
        // _rb.velocity = new Vector3(_movement.x, _rb.velocity.y, _movement.z);
        _rb.velocity = _movement;
    }
}