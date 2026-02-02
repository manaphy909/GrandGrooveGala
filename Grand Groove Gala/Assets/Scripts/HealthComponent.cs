using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;
    public Slider Healthbar;
    public Slider TimeBar;

    private AudioSource audioSource;
    //fadetoblack
    public Image fadeImage;
    public float fadeDuration = 1.5f;
    private float timer;

    private void Start()
    {
        //currentHealth = maxHealth;
        fadeImage.gameObject.SetActive(false);
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

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        loadScene();
    }
    private void loadScene()
    {
        StartCoroutine(FadeRoutine(0f, 1f));

    }
    private IEnumerator FadeRoutine(float startAlpha, float endAlpha)
    {
        timer = 0f;

        // Ensure the image is active before starting the fade
        if (!fadeImage.gameObject.activeSelf)
        {
            fadeImage.gameObject.SetActive(true);
        }

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            // Calculate the new alpha value using linear interpolation
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeDuration);

            // Apply the new color with the calculated alpha
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);

            yield return null; // Wait for the next frame
        }

        // Ensure the final alpha value is set precisely
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, endAlpha);

        if (timer >= fadeDuration) SceneManager.LoadScene(7);
    }

}
