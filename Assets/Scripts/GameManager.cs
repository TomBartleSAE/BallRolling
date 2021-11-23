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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        levelLoadedEvent?.Invoke();
    }

    public void SpawnPlayers()
    {
        Debug.Log("Spawn Function");
    }
}
