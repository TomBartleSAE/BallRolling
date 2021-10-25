using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : StateBase
{
    PlayerActionMap playerActionMap;

    public override void Enter()
    {
        //base.Enter();
        playerActionMap = new PlayerActionMap();
        playerActionMap.InMenu.Enable();

        Debug.Log("Entered Menu State");

        //Load Menu Scene
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public override void Execute()
    {
        //base.Execute();

        //Check if all players are ready, if yes change to InGameState

    }

    public override void Exit()
    {
        //base.Exit();

        playerActionMap.InMenu.Disable();

        Debug.Log("Exiting Menu State");
    }
}
