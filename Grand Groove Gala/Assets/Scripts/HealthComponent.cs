using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;
    public Slider Healthbar;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth()
    {

        Healthbar.maxValue = maxHealth;
        Healthbar.value = currentHealth;

    }

    public void SetHealth()
    {

        Healthbar.value = currentHealth;

    }


    private void Update()
    {

        if (currentHealth <= 0)
            Death();
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        SetHealth();
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
