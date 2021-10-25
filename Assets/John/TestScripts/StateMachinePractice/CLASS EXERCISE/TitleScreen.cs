using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : StateBase2
{
    public GameObject titleScreen;

    public override void Enter()
    {
        Debug.Log("ENTERED TITLE SCREEN");
        titleScreen.SetActive(true);
    }

    public override void Execute()
    {
        Debug.Log("Executing Title Screen");
    }

    public override void Exit()
    {
        Debug.Log("EXITING TITLE SCREEN");
        titleScreen.SetActive(false);
    }
}
