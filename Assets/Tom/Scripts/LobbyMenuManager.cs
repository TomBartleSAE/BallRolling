using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyMenuManager : MonoBehaviour
{
    public PlayerInputManager inputManager;

    public GameObject[] joinScreens = new GameObject[4];
    private int nextPlayerIndex = 0;

    public PlayerMenu[] playerMenus = new PlayerMenu[4];

    private void Awake()
    {
        inputManager.onPlayerJoined += AssignPlayerMenu;
    }

    private void AssignPlayerMenu(PlayerInput input)
    {
        joinScreens[nextPlayerIndex].SetActive(false);
        input.GetComponent<LobbyPlayer>().menu = playerMenus[nextPlayerIndex];
        nextPlayerIndex++;
    }
}
