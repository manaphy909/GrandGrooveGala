using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;
    public Slider Healthbar;
    public Slider TimeBar;


    private void Start()
    {
        //currentHealth = maxHealth;
    }

    public void SetMaxHealth()
    {

        Healthbar.maxValue = maxHealth;
        Healthbar.value = 0;

    }

    public void SetHealth()
    {

        Healthbar.value = currentHealth;

    }


    private void Update()
    {

        if (currentHealth >= 50)
            Death();
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth += damageAmount;
        SetHealth();
        if (currentHealth >= 50)
        {
            Death();
        }
        //Debug.Log(gameObject.name + " took " + damageAmount + " damage. Current health: " + currentHealth + " / " + maxHealth);
    }

    public void Death()
    {
        
    }
}
