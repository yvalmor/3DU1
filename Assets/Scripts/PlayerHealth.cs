using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxBullets = 20;
    public int currentHealth;
    public int currentBullets;

    public HealthBar healthBar;
    public BulletCounter bulletCounter;

    void Start()
    {
        // Set health to max
        currentHealth = maxHealth;
        // Set number of bullets to max
        currentBullets = maxBullets;
    }

    void Update()
    {
        // Code to Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    // function to fire a bullet
    void FireBullet()
    {
        // The player can fire
        if (currentBullets > 0)
        {
            currentBullets--;
            bulletCounter.SetBullet(currentBullets);
        }
    }

    // Reload bullets after 0.5 sec
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.5f);
        currentBullets = maxBullets;
        bulletCounter.SetBullet(currentBullets);
    }
}
