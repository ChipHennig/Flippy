using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MAX_HEALTH;

    private float currentHealth;

    public void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void gainHealth(float health)
    {
        currentHealth += health;

        if(currentHealth > MAX_HEALTH)
        {
            currentHealth = MAX_HEALTH;
        }
    }

    public float health
    {
        get
        {
            return currentHealth;
        }

        set
        {
            if(value < 0)
            {
                throw new ArgumentException();
            }
        }
    }

    public bool isAlive
    {
        get
        {
            return currentHealth >= 0;
        }
    }

}
