using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPoints;

    public GameObject test;
    public GameObject test2;

    public event Action<GameObject> SpawnPlayerEvent;
    public event Action<GameObject> SpawnAIEvent;

    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        OnLevelLoaded();

    }

    //Need to find a way for this to work from game manager
    private void OnLevelLoaded()
    {
        //Getting the total players from the player manager before the level loads (as I found an issue with players being added to the player manager on level load)
        //minusing 1 because lists & arrays start at 0 but int starts at 1
        int totalPlayers = playerManager.totalPlayers - 1;
        

        //For each spawn point, only spawn the corresponding amount of player balls to the amount of players in the game, otherwise spawn AI balls for all remaining spawn points
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i <= totalPlayers)
            {
                Instantiate(test, spawnPoints[i].position, spawnPoints[i].rotation);
            }
            else
            {
                Instantiate(test2, spawnPoints[i].position, spawnPoints[i].rotation);
            }
        }
    }
}
