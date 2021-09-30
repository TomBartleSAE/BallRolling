using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestActionMap testActionMap = new TestActionMap();
        testActionMap.InGame.Enable();

        testActionMap.InGame.Movement.performed += PlayerMovement;
    }

    //NEED TO FIX
    void PlayerMovement(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<Vector2>());
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
