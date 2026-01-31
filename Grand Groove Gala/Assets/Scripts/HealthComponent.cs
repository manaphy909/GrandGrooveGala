using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {

        if (currentHealth <= 0)
            Death();
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Death();
        }
        Debug.Log(gameObject.name + " took " + damageAmount + " damage. Current health: " + currentHealth + " / " + maxHealth);
    }

    public void Death()
    {
        
    }
}
