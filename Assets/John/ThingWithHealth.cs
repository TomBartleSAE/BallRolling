using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingWithHealth : MonoBehaviour
{
    public float deathTimer;

    void Start()
    {
        //StartCoroutine(KillObject());
        StartCoroutine(IncreaseHealth());
        //Invoke("InflictDamage", 5f);
    }

    void FixedUpdate()
    {
        deathTimer += Time.deltaTime;
    }
  
    void OnEnable()
    {
        HealthModel.DeathEvent += Die;
        HealthModel.MaxHealthEvent += MaxHealth;
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("This Object Is Now Dead");
    }

    //DAMAGE OBJECT
    IEnumerator KillObject()
    {
        print("I Will Die In 5 Seconds");

        yield return new WaitForSeconds(5f);

        this.GetComponent<HealthModel>().ChangeHealth(-50);

    }

    void MaxHealth()
    {
        print("MAX HEALTH REACHED");
    }

    //GIVE HEALTH
    IEnumerator IncreaseHealth()
    {
        print("I will reached max health in 5 Seconds");

        yield return new WaitForSeconds(5f);

        this.GetComponent<HealthModel>().ChangeHealth(50);

    }


    //void InflictDamage()
    // {
    //this.GetComponent<HealthModel>().ChangeHealth(-50);
    // }
}
