using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    //Allows each object to have unique health variable
    [SerializeField]
    public float myHealth;
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float deathThreshold;

    //Death Event
    public delegate void DeathSignature(GameObject ball);
    public event DeathSignature DeathEvent;

    public void Death()
    {
        DeathEvent?.Invoke(this.gameObject);
    }

    //Max Health Event
    public delegate void MaxHealthSignature();
    public event MaxHealthSignature MaxHealthEvent;

    public event System.Action<float> HealthChangedEvent;

    public void MaxHealth()
    {
        MaxHealthEvent?.Invoke();
    }

    //Manage Object Health (Can both increase or decrease health)
    public void ChangeHealth(float amount)
    {
        myHealth += amount;

        HealthChangedEvent?.Invoke(myHealth);

        //If health ever drops to 0 or below fire off DeathEvent
        if(myHealth <= deathThreshold)
        {
            Death();
        }

        //If health ever reaches max health or more, fire off MaxHealthEvent
        if(myHealth >= maxHealth)
        {
            MaxHealth();
        }
    }

    //Get Health
    public float GetHealth()
    {
        return myHealth;
    }


    //INSPECTOR BUTTONS
    public void DeathButton()
    {
        Death();
    }

    public void MaxHealthButton()
    {
        MaxHealth();
    }
}
