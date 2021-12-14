using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //State Manager References
    public StateManager stateManager;
    public StateBase inGameState;
    public StateBase inMenuState;

    public TransitionManager transition;

    public List<RollingBallModel> totalBalls = new List<RollingBallModel>();
    public GameObject winningBall;

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
    public void LoadLevel(string level)
    {
        //Load new level
        //SceneManager.LoadScene(level);
        //stateManager.ChangeState(inGameState);
        //levelLoadedEvent?.Invoke();

        StartCoroutine(LoadLevelCoroutine(level));
    }

    IEnumerator LoadLevelCoroutine(string level)
    {
        transition.NewSceneTransition();

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(level);
        stateManager.ChangeState(inGameState);
    }
}
