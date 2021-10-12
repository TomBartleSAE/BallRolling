using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStateManager : MonoBehaviour
{
    public StateBase2 currentState;

    //For Changing States Using Button
    public StateBase2 nextStateTest;

    private void Start()
    {
        currentState.Enter();
    }

    private void Update()
    {
        currentState.Execute();
    }
    public void ChangeState(StateBase2 newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
