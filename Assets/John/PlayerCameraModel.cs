using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraModel : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(0, 40, 0);
        transform.LookAt(target);
        transform.Rotate(new Vector3(0, 0, 90));
        //transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }
}