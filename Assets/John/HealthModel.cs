using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    float health = 50;
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
