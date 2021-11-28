using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyPlayer : MonoBehaviour
{
    // Gives input to a spawned player object and applies the chosen skin
    public PlayerInput input;
    public PlayerMenu menu;
    
    public Material skin;
    private int skinIndex;
    public Material[] allSkins;

    public bool isReady = false;
    public event Action ReadyUpEvent;

    //Need static for reference
    public static event Action NextButtonEvent;
    public static event Action PreviousButtonEvent;

    // Function to be called when player presses left/right in lobby
    // Used to select skin for player model in-game
    public void OnNavigate(InputAction.CallbackContext obj)
    {
        int horizontal = (int)obj.ReadValue<Vector2>().x;

        //Send events to view model for tweening
        if(horizontal > 0)
        {
            NextButtonEvent?.Invoke();
        }
        else if(horizontal < 0)
        {
            PreviousButtonEvent?.Invoke();
        }

        skinIndex += horizontal;
        // Wraps selection around start and end of skin array
        if (skinIndex < 0)
        {
            skinIndex = allSkins.Length - 1;
        }
        else if (skinIndex >= allSkins.Length)
        {
            skinIndex = 0;
        }

        skin = allSkins[skinIndex];
        menu?.SetSkin(skin);
    }

    public void OnSelect(InputAction.CallbackContext obj)
    {
        if (menu != null && menu.gameObject.activeInHierarchy)
        {
            isReady = !isReady;
            menu?.EnableReadyIcon(isReady);
            if (isReady)
            {
                ReadyUpEvent?.Invoke();
            }
        }
    }
}
