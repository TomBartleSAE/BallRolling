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

    ISelectable selectable;

    // Start is called before the first frame update
    void Start()
    {
        PlayerActionMap playerActionMap = new PlayerActionMap();
        playerActionMap.InMenu.Enable();

        playerActionMap.InMenu.Navigate.performed += SelectorMovement;
        playerActionMap.InMenu.Navigate.canceled += SelectorMovement;

        playerActionMap.InMenu.Select.performed += Selected;
    }

    //If a selectable is selected, call its interaction function
    void Selected(InputAction.CallbackContext callback)
    {
        if(selectable != null)
        {
            selectable.Interaction();
        }
    }

    private void LateUpdate()
    {
        //TODO: Fix this to not be hardcoded

        //Clamp selector in canvas bounds
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
        selectable = collision.GetComponent<ISelectable>();

        if(selectable != null)
        {
            selectable.PlayTween();
        }
    }

    //Reset Tween
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ISelectable>() != null)
        {
            collision.GetComponent<ISelectable>().ResetTween();
        }

        selectable = null;
    }

    //Update selectable to always be the current selectable the player is hovering over - this is because we are setting selectable to be null on TriggerExit which overrides TriggerEnters declaration
    private void OnTriggerStay2D(Collider2D collision)
    {
        selectable = collision.GetComponent<ISelectable>();
    }
}
