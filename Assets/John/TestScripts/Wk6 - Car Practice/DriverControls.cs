using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverControls : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float turnRadius = 10f;

    public Vector3 localVelocity;
    public Transform carTransform;

    public List<Transform> steeringWheels = new List<Transform>();
    public List<Transform> drivingWheels = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //localVelocity = transform.InverseTransformDirection(rb.velocity);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        localVelocity = carTransform.InverseTransformDirection(rb.velocity);

        float steering = Input.GetAxis("Horizontal") * turnRadius;

        foreach(Transform steeringWheel in steeringWheels)
        {
            steeringWheel.localRotation = Quaternion.Euler(0, steering, 0);
            rb.AddForceAtPosition(steeringWheel.forward * Input.GetAxis("Vertical") * speed, steeringWheel.position);
        }

        foreach (Transform driveWheel in drivingWheels)
        {
            //rb.AddRelativeForce(Input.GetAxis("Vertical") * driveWheel.forward * speed);
            rb.AddForceAtPosition(driveWheel.forward * Input.GetAxis("Vertical") * speed, driveWheel.position);
        }

        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Add Forward Movement
            rb.AddRelativeForce(Vector3.right * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Add Backward Movement
            rb.AddRelativeForce(Vector3.left * speed/2, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Add Left Rotation
            rb.AddRelativeTorque(Vector3.down * speed/4, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Add Right Rotation
            rb.AddRelativeTorque(Vector3.up * speed/4, ForceMode.Force);
        }
        */

        //rb.AddRelativeForce(Input.GetAxis("Vertical") * speed * transform.forward);
        //rb.AddRelativeTorque(Input.GetAxis("Horizontal") * speed * Vector3.up);

    }
}
