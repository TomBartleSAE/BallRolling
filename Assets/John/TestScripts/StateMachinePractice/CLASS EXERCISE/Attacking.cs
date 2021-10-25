using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacking : StateBase2
{
    public GameObject attackText;

    public override void Enter()
    {
        Debug.Log("ENTERED ATTACKING STATE");
        attackText.GetComponent<Text>().text = "Attacking State";
        attackText.SetActive(true);
    }

    public override void Execute()
    {
        Debug.Log("Executing Attack");
    }

    public override void Exit()
    {
        Debug.Log("EXITING ATTACKING STATE");
        StartCoroutine(TurnOffText());
    }



    IEnumerator TurnOffText()
    {
        attackText.GetComponent<Text>().text = "Exiting Attacking State...";

        yield return new WaitForSeconds(1.5f);

        attackText.SetActive(false);
    }
}
