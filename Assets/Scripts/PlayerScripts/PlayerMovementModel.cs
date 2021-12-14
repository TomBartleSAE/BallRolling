using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementModel : MonoBehaviour
{
    public Rigidbody rb;
    Vector2 playerInput;

    CameraTarget camTarget;
    public PlayerCameraModel cameraModel;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerActionMap playerActionMap = new PlayerActionMap();
        //playerActionMap.InGame.Enable();

        //playerActionMap.InGame.Movement.performed += PlayerMovement;
        //playerActionMap.InGame.Movement.canceled += PlayerMovement;

        camTarget = GetComponent<CameraTarget>();
    }

    //NEED TO FIX
    public void OnMovement(InputAction.CallbackContext obj)
    {
        playerInput = obj.ReadValue<Vector2>();
        //speed = 50;

        //rb.AddForce(new Vector3(playerInput.x, 0f, playerInput.y) * speed);
        //rb.MovePosition(rb.position * playerInput * speed * Time.fixedDeltaTime);
    }
    
    public void OnLookDirection(InputAction.CallbackContext obj)
    {
        //Debug.Log(obj.ReadValue<Vector2>();

        //pivot.Rotate(new Vector3(obj.ReadValue<Vector2>().y, obj.ReadValue<Vector2>().x, 0)*0.1f);

        //currentRotation = -obj.ReadValue<Vector2>().y;
        //currentRotation = Mathf.Clamp(currentRotation, -90, 90);
        //pivotX.localEulerAngles += new Vector3(0, obj.ReadValue<Vector2>().x, 0) * 0.1f;

        if (cameraModel != null)
        {
            cameraModel.currentRotation = obj.ReadValue<Vector2>().x;
        }

        //pivotY.localEulerAngles += new Vector3(currentRotation, 0, 0) * 0.1f;
    }

    void Update()
    {
        //rb.AddForce(new Vector3(playerInput.x, 0f, playerInput.y) * speed);


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (cameraModel != null)
        {
            Vector3 forwardDirection = camTarget.GetMyCamera().direction.forward * playerInput.y;
            Vector3 sideDirection = camTarget.GetMyCamera().direction.right * playerInput.x;

            Vector3 movementDirection = forwardDirection + sideDirection;

            //rb.AddTorque(new Vector3(playerInput.x, 0f, playerInput.y) * speed, ForceMode.Force);

            rb.AddForce(movementDirection * speed/4, ForceMode.Force);
        }


        //speed = 0;

        //rb.AddForce(new Vector3(playerInput.x, 0f, playerInput.y) * speed);

    }
}
