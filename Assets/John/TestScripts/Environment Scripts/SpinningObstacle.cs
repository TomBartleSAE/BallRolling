using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        rb.AddTorque(Vector3.up * rotateSpeed, ForceMode.VelocityChange);
    }
}
