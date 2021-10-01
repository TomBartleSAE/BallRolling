using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementModel : MonoBehaviour
{
    public Rigidbody rb;
    Vector2 playerInput;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        TestActionMap testActionMap = new TestActionMap();
        testActionMap.InGame.Enable();

        testActionMap.InGame.Movement.performed += PlayerMovement;
        testActionMap.InGame.Movement.canceled += PlayerMovement;
    }

    //NEED TO FIX
    void PlayerMovement(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<Vector2>());
        playerInput = obj.ReadValue<Vector2>();
        //speed = 50;

        //rb.AddForce(new Vector3(playerInput.x, 0f, playerInput.y) * speed);
        //rb.MovePosition(rb.position * playerInput * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        //rb.AddForce(new Vector3(playerInput.x, 0f, playerInput.y) * speed);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(new Vector3(playerInput.x, 0f, playerInput.y) * speed);

        rb.AddTorque(new Vector3(playerInput.x, 0f, playerInput.y) * speed, ForceMode.Force);


        //speed = 0;

        //rb.AddForce(new Vector3(playerInput.x, 0f, playerInput.y) * speed);

    }
}
