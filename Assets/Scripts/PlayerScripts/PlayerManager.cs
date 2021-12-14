using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public List<PlayerInput> players;
    public int totalPlayers;
    int playerCount;
    
    private PlayerInputManager inputManager;
    GameManager gameManager;

    private void Awake()
    {
        inputManager = GetComponent<PlayerInputManager>();
        inputManager.onPlayerJoined += PlayerJoined;
        DontDestroyOnLoad(this);
    }

    void PlayerJoined(PlayerInput newPlayer)
    {
        players.Add(newPlayer);
        totalPlayers++;
    }
}
