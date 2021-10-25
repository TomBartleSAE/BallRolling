using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idle : StateBase2
{
    public GameObject idleText;

    public override void Enter()
    {
        Debug.Log("ENTERED IDLE STATE");
        idleText.GetComponent<Text>().text = "Idle State";
        idleText.SetActive(true);
    }

    public override void Execute()
    {
        Debug.Log("Executing Idle");
    }

    public override void Exit()
    {
        Debug.Log("EXITING IDLE STATE");
        StartCoroutine(TurnOffText());
    }

    IEnumerator TurnOffText()
    {
        idleText.GetComponent<Text>().text = "Exiting Idle State...";

        yield return new WaitForSeconds(1.5f);

        idleText.SetActive(false);
    }
}
