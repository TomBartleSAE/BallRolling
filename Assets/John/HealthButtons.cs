using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthButtons : MonoBehaviour
{
    public void DeathButton()
    {
        FindObjectOfType<HealthModel>().DeathFunction();
    }
}
