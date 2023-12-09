using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public int InitialHealth;
    [HideInInspector]
    public int Health;
    public float Speed;

    void Awake()
    {
        Health = InitialHealth;
    }

    public void LoseHealth(int value)
    {
        //Show on print the value of health
        Debug.Log("Health: " + Health);
        Debug.Log("Value: " + value);

        if(Health - value <= 0)
        {
            Health = 0;
            return;
        }
        Health -= value;
    }

    
}