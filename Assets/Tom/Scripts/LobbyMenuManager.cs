using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyMenuManager : MonoBehaviour
{
    public PlayerManager playerManager;

    public GameObject[] joinScreens = new GameObject[4];
    private int nextPlayerIndex = 0;

    public PlayerMenu[] playerMenus = new PlayerMenu[4];

    public GameObject playerCanvas, levelCanvas;

    private void Awake()
    {
        playerManager.GetComponent<PlayerInputManager>().onPlayerJoined += AssignPlayerMenu;
    }

    private void AssignPlayerMenu(PlayerInput input)
    {
        joinScreens[nextPlayerIndex].SetActive(false);
        input.GetComponent<LobbyPlayer>().menu = playerMenus[nextPlayerIndex];
        input.GetComponent<LobbyPlayer>().ReadyUpEvent += ShowLevelSelect;
        nextPlayerIndex++;
    }

    private void ShowLevelSelect()
    {
        int readyPlayers = 0;
        foreach (PlayerInput player in playerManager.players)
        {
            if (player.GetComponent<LobbyPlayer>().isReady)
            {
                readyPlayers++;
            }
        }

        if (readyPlayers >= playerManager.players.Count)
        {
            playerCanvas.SetActive(false);
            levelCanvas.SetActive(true);
        }
    }
}
