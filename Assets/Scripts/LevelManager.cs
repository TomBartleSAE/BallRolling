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
        /*
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (playerManager != null)
            {
                if (i < playerManager.players.Count)
                {
                    Instantiate(test, spawnPoints[i].position, spawnPoints[i].rotation);
                }
                else
                {
                    Instantiate(test2, spawnPoints[i].position, spawnPoints[i].rotation);
                }
            }
        }
        */

        
        foreach(Transform t in spawnPoints)
        {
            //foreach(PlayerInput p in playerManager.players)
            {
                Instantiate(test, t.position, t.rotation);
            }

            //Instantiate(test2, t.position, t.rotation);

        }
        
    }
}
