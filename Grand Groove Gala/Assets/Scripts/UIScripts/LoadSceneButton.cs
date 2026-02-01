
/*******************************************************************************
File: Again.cs
Author: Atlas Stewart
DP Email: atlas.stewart@digipen.edu
Date: 9/22/2024
Course: CS116
Section: B
Description:
Restart code
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    //fadetoblack
    public Image fadeImage;
    public float fadeDuration = 1.5f;
    private float timer;

    public Button button;
    public int sceneToLoad;
    private void Start()
    {
        fadeImage.gameObject.SetActive(false);
        button = GetComponent<Button>();
        button.onClick.AddListener(loadScene);
    }
    public void loadScene()
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
            
            if(timer >= fadeDuration)SceneManager.LoadScene(sceneToLoad);

        }

}

