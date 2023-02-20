using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GameObject GravityArea;
    public float Gravity = 9.81f;
    void Start()
    {
    }
    
    void FixedUpdate()
    {
        if (GravityArea)
        {
            //ignore the collision between the player and the gravity area
            Physics.IgnoreCollision(GetComponent<Collider>(), GravityArea.GetComponent<Collider>());
            // get center of gravity area
            Vector3 gravityCenter = GravityArea.transform.position;
            // set gravity direction to center of gravity area
            Vector3 gravityDirection = (gravityCenter - transform.position).normalized;
            // apply gravity
            GetComponent<Rigidbody>().AddForce(gravityDirection * Gravity);
            // rotate rb top to gravity direction
            Quaternion targetRotation = Quaternion.FromToRotation(-transform.up, gravityDirection) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.deltaTime);
            
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GravityArea"))
        {
            GravityArea = collision.gameObject;
        }
    }
}
