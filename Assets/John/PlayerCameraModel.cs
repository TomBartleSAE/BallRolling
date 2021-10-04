using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraModel : MonoBehaviour
{
    public Transform target;
    public Transform pivotX;

    float currentRotation = 0;

    public Camera cam;
    float zDefaultOffset;

    Rigidbody targetRB;
    bool targetHasRB = false;

    [SerializeField]
    float velocityMultiplier = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTarget(target);

        zDefaultOffset = cam.transform.localPosition.z;

        //TestActionMap testActionMap = new TestActionMap();
        //testActionMap.InGame.Enable();

        //testActionMap.InGame.LookDirection.performed += PlayerCamTest;
    }

    
    void PlayerCamTest(InputAction.CallbackContext obj)
    {
        //Debug.Log(obj.ReadValue<Vector2>();

        //pivot.Rotate(new Vector3(obj.ReadValue<Vector2>().y, obj.ReadValue<Vector2>().x, 0)*0.1f);

        currentRotation = -obj.ReadValue<Vector2>().y;
        currentRotation = Mathf.Clamp(currentRotation, -90, 90);
        pivotX.localEulerAngles += new Vector3(0, obj.ReadValue<Vector2>().x, 0) * 0.1f;

        //pivotY.localEulerAngles += new Vector3(currentRotation, 0, 0) * 0.1f;
    }


    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TestActionMap testActionMap = new TestActionMap();
            testActionMap.InGame.Enable();

            testActionMap.InGame.LookDirection.performed += PlayerCamTest;
        }

        transform.position = target.position;

        if(targetHasRB)
        {
            float targetVelocity = targetRB.velocity.magnitude * velocityMultiplier;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, zDefaultOffset - targetVelocity);
        }
        //transform.LookAt(target);


        //transform.Rotate(new Vector3(0, 90, 0));
        //transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }

    //CHANGE CAMERA TARGET
    public void ChangeTarget(Transform newTarget)
    {
        if(newTarget.GetComponent<Rigidbody>() != null)
        {
            targetHasRB = true;
            targetRB = newTarget.GetComponent<Rigidbody>();
        }
        else
        {
            targetHasRB = false;
            targetRB = null;
        }

        //Setting the target
        target = newTarget;

        //Getting the component from the target and assigning the camera to this target
        target.GetComponent<CameraTarget>().SetMyCamera(this);
    }
}
