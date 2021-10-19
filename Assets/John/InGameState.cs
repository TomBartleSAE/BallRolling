using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameState : StateBase
{
    TestActionMap testActionMap;

    public override void Enter()
    {
        //base.Enter();
        testActionMap = new TestActionMap();
        testActionMap.InGame.Enable();

        Debug.Log("Entered Game State");

        //If the current scene is not scene 1, load scene 1
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            //TODO: Remove this once we have level select functionality 
            //will need to load scene based on a given input
            SceneManager.LoadScene(1);
        }

    }


    public override void Execute()
    {
        //base.Execute();

        //Check if there is only 1 player alive / or game mode condition has been met
        //EndGame()

    }

    public override void Exit()
    {
        //base.Exit();

        testActionMap.InGame.Disable();

        Debug.Log("Exiting Game State");
    }
}
