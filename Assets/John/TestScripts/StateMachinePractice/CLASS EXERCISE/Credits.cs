using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : StateBase2
{
    public GameObject creditScreen;

    public override void Enter()
    {
        Debug.Log("ENTERED CREDIT SCREEN");
        creditScreen.SetActive(true);
    }

    public override void Execute()
    {
        Debug.Log("ROLLING CREDITS");
    }

    public override void Exit()
    {
        Debug.Log("EXITING CREDIT SCREEN");
        creditScreen.SetActive(false);
    }
}
