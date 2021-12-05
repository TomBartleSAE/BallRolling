using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public StateBase inGameState;
    public StateBase inMenuState;

    public LevelManager levelManager;

    //Events
    public event Action levelLoadedEvent;

    private void Awake()
    {
        //Only set instance as a reference if there are no other references
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LevelManager.SpawnPlayerEvent += SpawnPlayers;
        LevelManager.SpawnAIEvent += SpawnAI;
    }

    public void LoadLevel(string level)
   {
        //Load new level
        SceneManager.LoadScene(level);

        //Find that levels level manager
        //levelManager = FindObjectOfType<LevelManager>();
        //levelManager.SpawnPlayerEvent += SpawnPlayers;
        //levelManager.SpawnAIEvent += SpawnAI;

        levelLoadedEvent?.Invoke();
   }

    void SpawnPlayers(Transform spawnPos, GameObject player)
    {
        //Instantiate(player, spawnPos.position, spawnPos.rotation);
        Debug.Log("Player Spawned");
    }

    void SpawnAI(Transform spawnPos, GameObject aiBall)
    {
        //Instantiate(aiBall, spawnPos.position, spawnPos.rotation);
        Debug.Log("AI Spawned");
    }
}
