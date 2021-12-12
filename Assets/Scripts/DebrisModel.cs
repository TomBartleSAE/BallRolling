using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisModel : MonoBehaviour
{
    [SerializeField] private float size;
    
    public float GetSize()
    {
        return size;
    }
    
    // Prevents getting stuck when spawning inside ball
    public IEnumerator DelayCollider()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<Collider>().enabled = true;
    }

    public void Absorb(GameObject ball)
    {
        // Replace with tweened animation of debris going into ball
        
        ball.SetActive(false);
    }

    private void OnEnable()
    {
        GetComponent<HealthModel>().DeathEvent += Absorb;
    }

    private void OnDisable()
    {
        GetComponent<HealthModel>().DeathEvent += Absorb;
    }
}
