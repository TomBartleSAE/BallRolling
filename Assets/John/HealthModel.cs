using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    //Allows each object to have unique health variable
    [SerializeField]
    float myHealth;
    [SerializeField]
    float maxHealth;

    //DEATH EVENT
    public delegate void DeathSignature();
    public static event DeathSignature DeathEvent;

    public static void DeathFunction()
    {
        DeathEvent?.Invoke();
    }

    //MAX HEALTH EVENT
    public delegate void MaxHealthSignature();
    public static event MaxHealthSignature MaxHealthEvent;

    public static void MaxHealthFunction()
    {
        MaxHealthEvent?.Invoke();
    }

    //Manage Object Health (Can both increase or decrease health)
    public void ChangeHealth(float amount)
    {
        myHealth += amount;

        //If health ever drops to 0 or below fire off DeathEvent
        if(myHealth <= 0)
        {
            DeathFunction();
        }

        //If health ever reaches max health or more, fire off MaxHealthEvent
        if(myHealth >= maxHealth)
        {
            MaxHealthFunction();
        }
    }


    //INSPECTOR BUTTONS
    public void DeathButton()
    {
        DeathFunction();
    }

    public void MaxHealthButton()
    {
        MaxHealthFunction();
    }


}
