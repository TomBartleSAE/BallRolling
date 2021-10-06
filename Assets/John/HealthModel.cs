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
    [SerializeField]
    float deathThreshold;

    //DEATH EVENT
    public delegate void DeathSignature();
    public event DeathSignature DeathEvent;

    public void DeathFunction()
    {
        DeathEvent?.Invoke();
    }

    //MAX HEALTH EVENT
    public delegate void MaxHealthSignature();
    public event MaxHealthSignature MaxHealthEvent;

    public void MaxHealthFunction()
    {
        MaxHealthEvent?.Invoke();
    }

    //Manage Object Health (Can both increase or decrease health)
    public void ChangeHealth(float amount)
    {
        myHealth += amount;

        //If health ever drops to 0 or below fire off DeathEvent
        if(myHealth <= deathThreshold)
        {
            DeathFunction();
        }

        //If health ever reaches max health or more, fire off MaxHealthEvent
        if(myHealth >= maxHealth)
        {
            MaxHealthFunction();
        }
    }

    //GET HEALTH
    public float GetHealth()
    {
        return myHealth;
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
