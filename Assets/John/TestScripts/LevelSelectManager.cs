using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

//TODO: Rename Script to SelectorManager
public class LevelSelectManager : MonoBehaviour
{
    [SerializeField]
    GameObject selector;

    Vector2 playerInput;
    public Rigidbody2D rb;

    [SerializeField]
    int speed = 5;

    string level;

    public event Action<string> currentLevelEvent;

    // Start is called before the first frame update
    void Start()
    {
        PlayerActionMap playerActionMap = new PlayerActionMap();
        playerActionMap.InMenu.Enable();

        playerActionMap.InMenu.Navigate.performed += SelectorMovement;
        playerActionMap.InMenu.Navigate.canceled += SelectorMovement;
    }

    void SelectorMovement(InputAction.CallbackContext value)
    {
        playerInput = value.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(playerInput * speed, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        level = collision.GetComponent<LevelReference>().levelID;
        if(level != null)
        {
            Debug.Log(level);

            //Can Launch level directly from here or can send the level info to a manager? SceneManager.LoadScene(level) etc
            currentLevelEvent?.Invoke(level);
        }

        //Play Tween Animation if object is tweenable
        if(collision.GetComponent<ITweenable>() != null)
        {
            collision.GetComponent<ITweenable>().PlayTween();
        }
    }
}
