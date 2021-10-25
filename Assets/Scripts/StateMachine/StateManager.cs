using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public StateBase currentState;

    //For Changing States Using Button
    //public StateBase2 nextStateTest;

    private void Start()
    {
        currentState.Enter();
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Execute();
    }

    public void ChangeState(StateBase newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
