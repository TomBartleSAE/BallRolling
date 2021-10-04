using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraModel : MonoBehaviour
{
    public Transform target;
    Camera cam;

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();

       // TestActionMap testActionMap = new TestActionMap();
        //testActionMap.InGame.Enable();

        //testActionMap.InGame.LookDirection.performed += PlayerCamTest;
    }

    void PlayerCamTest(InputAction.CallbackContext obj)
    {
        //Debug.Log(cam.ScreenToWorldPoint(obj.ReadValue<Vector2>()));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(25, 15, 0);
        //transform.LookAt(target);


        //transform.Rotate(new Vector3(0, 90, 0));
        //transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }
}
