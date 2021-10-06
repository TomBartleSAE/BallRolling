using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSecondTestState : StateBase
{
    bool triggered = false;
    public override void Enter()
    {
        //base.Enter();

        Debug.Log("Entering SecondTest State");
    }

    public override void Execute()
    {
        //base.Execute();

        if(!triggered)
        {
            triggered = true;
            Debug.Log("STATE 2 NOW RUNNING...");
        }
    }

    public override void Exit()
    {
        //base.Exit();

        Debug.Log("Exiting SecondTest State");
        triggered = false;
    }
}
