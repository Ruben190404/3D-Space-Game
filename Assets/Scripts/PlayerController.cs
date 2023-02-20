using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    private float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _Hinput = Input.GetAxis("Horizontal");
        float _Vinput = Input.GetAxis("Vertical");
        Vector3 _movement = (transform.right * _Hinput + transform.forward * _Vinput) * _speed;
        _rb.velocity = new Vector3(_movement.x, _rb.velocity.y, _movement.z);
    }
}