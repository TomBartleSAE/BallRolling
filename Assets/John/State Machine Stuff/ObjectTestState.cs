using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTestState : StateBase
{
    bool triggered = false;

    public override void Enter()
    {
        //base.Enter();

        Debug.Log("Entering Test State");
    }

    public override void Execute()
    {
        //base.Execute();

        if (!triggered)
        {
            triggered = true;
            Debug.Log("STATE 1 NOW RUNNING...");
        }
    }

    public override void Exit()
    {
        //base.Exit();

        Debug.Log("Exiting Test State");
        triggered = false;
    }

}
