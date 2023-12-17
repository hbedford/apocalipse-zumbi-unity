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

        if(Health - value <= 0)
        {
            Health = 0;
            return;
        }
        Health -= value;
    }

    public void Heal(int value)
    {
        if(Health + value >= InitialHealth)
        {
            Health = InitialHealth;
            Debug.Log("Health: " + Health);
            return;
        }
        Health += value;
    }

    
}
