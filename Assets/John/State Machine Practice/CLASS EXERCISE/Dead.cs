using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : StateBase2
{
    public GameObject deadUI;

    public override void Enter()
    {
        Debug.Log("ENTERED DEAD STATE");
        deadUI.SetActive(true);
    }

    public override void Execute()
    {
        Debug.Log("Dying...");
    }

    public override void Exit()
    {
        Debug.Log("EXITING DEAD STATE");
        deadUI.SetActive(false);
    }
}
