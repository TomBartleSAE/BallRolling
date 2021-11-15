using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraModel : MonoBehaviour
{
    public Transform target;
    public Transform direction;

    float currentRotation = 0;

    public float zDefaultOffset = 3f;
    public Vector3 yOffset;

    Rigidbody targetRB;
    bool targetHasRB = false;

    [SerializeField] float velocityMultiplier = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTarget(target);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        //zDefaultOffset = cam.transform.localPosition.z;

        //PlayerActionMap playerActionMap = new PlayerActionMap();
        //playerActionMap.InGame.Enable();

        //playerActionMap.InGame.LookDirection.performed += PlayerCamTest;
        //playerActionMap.InGame.LookDirection.canceled += PlayerCamTest;
    }


    public void OnLookDirection(InputAction.CallbackContext obj)
    {
        //Debug.Log(obj.ReadValue<Vector2>();

        //pivot.Rotate(new Vector3(obj.ReadValue<Vector2>().y, obj.ReadValue<Vector2>().x, 0)*0.1f);

        //currentRotation = -obj.ReadValue<Vector2>().y;
        //currentRotation = Mathf.Clamp(currentRotation, -90, 90);
        //pivotX.localEulerAngles += new Vector3(0, obj.ReadValue<Vector2>().x, 0) * 0.1f;

        currentRotation = obj.ReadValue<Vector2>().x;

        //pivotY.localEulerAngles += new Vector3(currentRotation, 0, 0) * 0.1f;
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position;

        transform.localEulerAngles += new Vector3(0f, currentRotation, 0f);
        transform.position = target.position - transform.forward * zDefaultOffset + yOffset;

        
        if(targetHasRB)
        {
            float targetVelocity = targetRB.velocity.magnitude * velocityMultiplier;
            transform.localPosition -= transform.forward * targetVelocity;
        }
        
        //transform.LookAt(target);


        //transform.Rotate(new Vector3(0, 90, 0));
        //transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }

    //CHANGE CAMERA TARGET
    public void ChangeTarget(Transform newTarget)
    {
        if (newTarget.GetComponent<Rigidbody>() != null)
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