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

    public void Absorb()
    {
        // Replace with tweened animation of debris going into ball
        
        gameObject.SetActive(false);
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
