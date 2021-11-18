using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

public class PlayerSelectorModel : MonoBehaviour
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

        playerActionMap.InMenu.Select.performed += Selected;
    }

    void Selected(InputAction.CallbackContext callback)
    {
        SceneManager.LoadScene(level);
    }

    private void LateUpdate()
    {
        //Clamp selector in canvas 
        Vector3 viewPos = transform.localPosition;
        viewPos.x = Mathf.Clamp(viewPos.x, -907, 901);
        viewPos.y = Mathf.Clamp(viewPos.y, -480, 480);
        transform.localPosition = viewPos;
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

    //Reset Tween Objects
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ITweenable>() != null)
        {
            collision.GetComponent<ITweenable>().ResetTween();
        }
    }
}
