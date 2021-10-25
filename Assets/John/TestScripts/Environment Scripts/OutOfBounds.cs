using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform respawnPoint;



    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Rigidbody>() != null)
        {
            //DAMAGE PLAYER

            //other.transform.position = respawnPoint.position;
            Debug.Log("DeadZone Hit");
        }
    }

}
