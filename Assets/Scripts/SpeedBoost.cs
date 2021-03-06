using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpeedBoost : MonoBehaviour
{
    private CameraTarget camTarget;
    private Rigidbody rb;
    private RollingBallModel ball;
    public float speed = 20f;
    public float decayRate = 0.005f;
    private float boosting = 0f;
    private float healthLost = 0f;

    private void Awake()
    {
        camTarget = GetComponent<CameraTarget>();
        rb = GetComponent<Rigidbody>();
        ball = GetComponent<RollingBallModel>();

        //PlayerActionMap playerActionMap = new PlayerActionMap();
        //playerActionMap.InGame.Enable();

        //playerActionMap.InGame.Ability.performed += Activate;
        //playerActionMap.InGame.Ability.canceled += Activate;
    }

    private void FixedUpdate()
    {
        if (boosting > 0)
        {
            Vector3 forwardDirection = camTarget.GetMyCamera().direction.forward;
            rb.AddForce(forwardDirection * speed * boosting, ForceMode.Force);
            ball.ChangeSize(-decayRate * boosting);
        }

        if (ball.absorbedDebris.Count > 0)
        {
            float threshold = ball.absorbedDebris.Peek().GetSize();
            healthLost += decayRate * boosting;

            if (healthLost > threshold)
            {
                ball.LoseDebris();
                healthLost = 0f;
            }
        }
    }

    public void OnAbility(InputAction.CallbackContext obj)
    {
        boosting = obj.ReadValue<float>();
    }
}
