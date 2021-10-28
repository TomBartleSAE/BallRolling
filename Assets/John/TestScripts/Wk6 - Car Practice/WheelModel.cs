using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelModel : MonoBehaviour
{
    public float suspensionLength = 10f;
    public float maxHeight = 1f;
    public float force = 0;
    public float maxForce = 1f;

    public AnimationCurve suspensionCurve;
    public float suspensionValue;

    public Rigidbody rb;

    public bool useAnimCurve;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Container for useful info coming from casting functions (note ‘out’ below)
        RaycastHit hitinfo;
        hitinfo = new RaycastHit();

        Physics.Raycast(transform.position, -transform.up, out hitinfo, suspensionLength, 255, QueryTriggerInteraction.Ignore);

        // Debug: Only draw line if we hit something
        if (hitinfo.collider)
        {
            float height;
            height = hitinfo.distance;
            force = maxHeight - height;
            force *= maxForce;
            suspensionValue = suspensionCurve.Evaluate(force);

            if(useAnimCurve)
            {
                //rb.AddRelativeForce(Vector3.up * suspensionValue, ForceMode.Impulse);
                rb.AddForceAtPosition(transform.up * force, transform.position);
            }
            else
            {
                //rb.AddRelativeForce(transform.TransformDirection(Vector3.forward) * force, ForceMode.Impulse);
                rb.AddForceAtPosition(transform.up * force, transform.position);

            }


            Debug.DrawLine(transform.position, hitinfo.point, Color.green);
        }

    }
}
