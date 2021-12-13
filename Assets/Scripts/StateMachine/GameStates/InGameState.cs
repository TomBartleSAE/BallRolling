using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameState : StateBase
{
    PlayerActionMap playerActionMap;
    GameManager gameManager;
    LevelManager levelManager;

    public List<PlayerMovementModel> playerBalls = new List<PlayerMovementModel>();
    public List<AIBallModel> aiBalls = new List<AIBallModel>();

    public override void Enter()
    {
        //base.Enter();
        playerActionMap = new PlayerActionMap();
        playerActionMap.InGame.Enable();

        gameManager = GetComponent<GameManager>();
        SubscribeToEvents();

        Debug.Log("Entered Game State");

    }


    public override void Execute()
    {
        //base.Execute();

        //Check if there is only 1 player alive / or game mode condition has been met
    }

    public override void Exit()
    {
        //base.Exit();

        playerActionMap.InGame.Disable();

        Debug.Log("Exiting Game State");
    }

    void RemoveBall(GameObject ball)
    {
        //Remove the ball that just died from the list
        gameManager.totalBalls.Remove(ball.GetComponent<RollingBallModel>());

        //Clear list before adding more to the list to stop duplicates
        playerBalls.Clear();
        aiBalls.Clear();

        //Check what balls are left are removing the last ball
        foreach (RollingBallModel rbm in gameManager.totalBalls)
        {
            //Find all players left in the game
            if (rbm.GetComponent<PlayerMovementModel>() != null)
            {
                playerBalls.Add(rbm.GetComponent<PlayerMovementModel>());
            }

            //Find all AI left in the game
            if (rbm.GetComponent<AIBallModel>() != null)
            {
                aiBalls.Add(rbm.GetComponent<AIBallModel>());
            }
        }

        //Check if all players have been eliminated
        if (playerBalls.Count <= 0)
        {
            gameManager.winningBall = null;
            LoadEndGameScene();
        }
        //If all AI are dead and only 1 player remains
        else if (aiBalls.Count <= 0 && playerBalls.Count == 1)
        {
            gameManager.winningBall = playerBalls[0].gameObject;
            LoadEndGameScene();
        }


    }

    void LoadEndGameScene()
    {
        SceneManager.LoadScene("EndScreen");
    }

    void SubscribeToEvents()
    {
        foreach(RollingBallModel ball in gameManager.totalBalls)
        {
            ball.GetComponent<HealthModel>().DeathEvent += RemoveBall;
        }
    }
}
