using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    [SerializeField]
    Transform launchDirection;

    [SerializeField]
    float speed;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponentInParent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(launchDirection.up * speed, ForceMode.VelocityChange);
        }
    }
}
