using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TomActionTest actions = new TomActionTest();
        //actions.InGame.Enable();

        //actions.InGame.Movement.performed += MoveOnPerformed;
    }

    private void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<Vector2>());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
