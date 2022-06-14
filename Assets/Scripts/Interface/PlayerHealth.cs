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
    public GameObject popUpReaload;

    // Start is called before the first frame update
    void Start()
    {
        if (bulletCounter is null)
            Debug.LogError("BulletCounter is null");

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentBullets = maxBullets;
        bulletCounter.SetMaxBullet(maxBullets);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            FireBullet();
        }
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
        currentBullets--;
        bulletCounter.SetBullet(currentBullets);
    }

    IEnumerator Reload()
    {
        popUpReaload.SetActive(true);
        yield return new WaitForSeconds(2);
        currentBullets = maxBullets;
        bulletCounter.SetBullet(currentBullets);
        popUpReaload.SetActive(false);
    }
}
