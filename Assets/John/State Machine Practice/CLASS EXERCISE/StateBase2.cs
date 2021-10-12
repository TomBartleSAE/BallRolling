using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase2 : MonoBehaviour
{
    public virtual void Enter()
    {
        Debug.Log("StateBase");
    }

    public virtual void Execute()
    {

    }

    public virtual void Exit()
    {

    }
}
