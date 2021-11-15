using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager inputManager;

    private void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        inputManager.onPlayerJoined += PlayerJoined;
    }

    void PlayerJoined(PlayerInput newPlayer)
    {
        Debug.Log("Player Joined");
    }
}
