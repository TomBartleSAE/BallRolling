using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    [SerializeField]
    float health;
    //public float max

    public delegate void HealthSignature();
    public static event HealthSignature DeathEvent;

    public static void DeathFunction()
    {
        DeathEvent?.Invoke();
    }

    public void ChangeHealth(float amount)
    {
        health += amount;

        if(health <= 0)
        {
            DeathFunction();
        }
    }

    public void DeathButton()
    {
        HealthModel.DeathFunction();
    }


}
