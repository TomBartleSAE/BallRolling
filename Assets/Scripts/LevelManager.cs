using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPoints;

    public PlayerMovementModel player;
    public AIBallModel aiBall;
    public PlayerCameraModel playerCamera;

    List<PlayerCameraModel> totalCameras = new List<PlayerCameraModel>();

    PlayerManager playerManager;
    int totalPlayers;

    // Start is called before the first frame update
    void Start()
    {
        //playerManager = FindObjectOfType<PlayerManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        //GameManager.Instance.levelLoadedEvent += OnLevelLoaded;
        OnLevelLoaded();

    }

    //Need to find a way for this to work from game manager
    public void OnLevelLoaded()
    {
        //Getting the total players from the player manager before the level loads (as I found an issue with players being added to the player manager on level load)
        //minusing 1 because lists & arrays start at 0 but int starts at 1
        if(playerManager?.totalPlayers > 0)
        {
            totalPlayers = playerManager.totalPlayers - 1;
        }
        

        //For each spawn point, only spawn the corresponding amount of player balls to the amount of players in the game, otherwise spawn AI balls for all remaining spawn points
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i <= totalPlayers)
            {
                //Spawning the player prefabs
                //PlayerMovementModel newPlayer = Instantiate(player, spawnPoints[i].position, spawnPoints[i].rotation);
                PlayerInput newPlayer = playerManager.players[i];
                newPlayer.transform.position = spawnPoints[i].position;
                newPlayer.GetComponent<Rigidbody>().isKinematic = false;
                newPlayer.SwitchCurrentActionMap("InGame");
                PlayerCameraModel newCamera = Instantiate(playerCamera, spawnPoints[i].position, Quaternion.Euler(25f, 0,0));

                //Assigning camera references
                newPlayer.GetComponent<PlayerMovementModel>().camera = newCamera;
                newCamera.target = newPlayer.transform;

                //Add all spawned players + cameras to lists for keeping track
                GameManager.Instance.totalBalls.Add(newPlayer.GetComponent<RollingBallModel>());
                totalCameras.Add(newCamera);
            }
            else
            {
                AIBallModel newAI = Instantiate(aiBall, spawnPoints[i].position, spawnPoints[i].rotation);
                GameManager.Instance.totalBalls.Add(newAI.GetComponent<RollingBallModel>());

            }
        }

        SetupCameras();
        GameManager.Instance.stateManager.ChangeState(GameManager.Instance.inGameState);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthModel>() != null)
        {
            //TODO: Damage & Respawn Player at a spawn point

            Debug.Log("DeadZone Hit");
        }
    }

    void SetupCameras()
    {
        if (totalCameras.Count == 1)
        {
            //Full Screen
            totalCameras[0].GetComponent<Camera>().rect = new Rect(0, 0, 1f, 1f);
        }
        if (totalCameras.Count == 2)
        {
            totalCameras[0].GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1f);
            totalCameras[1].GetComponent<Camera>().rect = new Rect(0.5f, 0, 1f, 1f);
        }
    }
}
