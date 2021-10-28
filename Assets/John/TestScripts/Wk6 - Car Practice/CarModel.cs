using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarModel : MonoBehaviour
{
    public Vector3 localVelocity;
    public float xVelocity;
    public Rigidbody rb;

    public float frictionAmount = 5f;

    public Text speedUI;
    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        speedUI.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        localVelocity = transform.InverseTransformDirection(rb.velocity);

        xVelocity = localVelocity.x;
        int speed = (int) localVelocity.z * 10;
        
        rb.AddRelativeForce(Vector3.right * xVelocity * -frictionAmount);

        //Mathf.Abs always returns the value as positive since speed can't be negative
        speedUI.text = ""+ Mathf.Abs(speed); 

        /*
        if(speed > 50)
        {
            smoke.Play();
        }
        else
        {
            smoke.Stop();
        }
        */
    }
}
