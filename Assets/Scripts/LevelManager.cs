using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPoints;

    public GameObject player;
    public GameObject aiBall;

    public static event Action<Transform, GameObject> SpawnPlayerEvent;
    public static event Action<Transform, GameObject> SpawnAIEvent;

    PlayerManager playerManager;
    GameManager gameManager;
    int totalPlayers;

    // Start is called before the first frame update
    void Start()
    {
        //playerManager = FindObjectOfType<PlayerManager>();
        //gameManager = FindObjectOfType<GameManager>();
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
                //Instantiate(player, spawnPoints[i].position, spawnPoints[i].rotation);
                SpawnPlayerEvent?.Invoke(spawnPoints[i], player);
                Debug.Log("Player Counter");

            }
            else
            {
                //Instantiate(aiBall, spawnPoints[i].position, spawnPoints[i].rotation);
                SpawnAIEvent?.Invoke(spawnPoints[i], aiBall);
                Debug.Log("Player Counter");
            }
        }
    }
}
