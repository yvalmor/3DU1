using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxBullets = 20;
    public int currentHealth;
    public int currentBullets;

    public HealthBar healthBar;
    public BulletCounter bulletCounter;
    public CanvasGroup popUpReload;

    void Start()
    {
        // Set health to max
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // Set number of bullets to max
        currentBullets = maxBullets;
        bulletCounter.SetMaxBullet(maxBullets);
        // Make disappear popup for reload 
        popUpReload.alpha = 0;
    }

    void Update()
    {
        /* Only for test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            FireBullet();
        }*/

        // Code to Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void FireBullet()
    {
        // The player can fire
        if (currentBullets > 0)
        {
            currentBullets--;
            bulletCounter.SetBullet(currentBullets);
        }
        // The player need to reload
        if (currentBullets == 0)
            StartCoroutine(NeedReload());
    }

    // Reload bullets after 0.5 sec
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.5f);
        currentBullets = maxBullets;
        bulletCounter.SetBullet(currentBullets);
    }

    IEnumerator NeedReload()
    {
        // Fade in popup for reload
        StartCoroutine(FadeCanvasGroup(popUpReload, popUpReload.alpha, 1));
        // Wait until the player reload
        while (currentBullets == 0)
            yield return null;
        // Fade out popup for reload
        StartCoroutine(FadeCanvasGroup(popUpReload, popUpReload.alpha, 0));
    }

    // Function to fade in or fade out a CanvasGroup
    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float startTime = Time.time;
        float duration = Time.time - startTime;
        float currPercent = duration / lerpTime;

        while (true)
        {
            duration = Time.time - startTime;
            currPercent = duration / lerpTime;
            float currValue = Mathf.Lerp(start, end, currPercent);
            cg.alpha = currValue;

            if (currPercent >= 1)
                break;
            yield return new WaitForEndOfFrame();
        }
    }
}
