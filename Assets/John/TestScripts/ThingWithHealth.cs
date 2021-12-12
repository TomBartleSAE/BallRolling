using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingWithHealth : MonoBehaviour
{
    public float deathTimer;
    HealthModel myHealth;

    void Awake()
    {
        myHealth = GetComponent<HealthModel>();
    }

    void Start()
    {
        //StartCoroutine(KillObject());
        //StartCoroutine(IncreaseHealth());

        //Invoke("InflictDamage", 5f);

    }

    void FixedUpdate()
    {
        deathTimer += Time.deltaTime;
    }
  
    void OnEnable()
    {
        myHealth.DeathEvent += Die;
        myHealth.MaxHealthEvent += MaxHealth;
    }

    void Die(GameObject me)
    {
        Destroy(me);
        Debug.Log("This Object Is Now Dead");
    }

    void MaxHealth()
    {
        print("MAX HEALTH REACHED");
    }

    //DAMAGE OBJECT
    IEnumerator KillObject()
    {
        print("I Will Die In 5 Seconds");

        yield return new WaitForSeconds(5f);

        this.GetComponent<HealthModel>().ChangeHealth(-50);

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
