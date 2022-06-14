using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform _tr;
    
    public ObjectPool _pool;
    public float startingDelay = 0f;
    public float repeatDelay = 10f;
    public float expusionForce = 1f;

    private void Awake()
    {
        _tr = transform;
    }

    private void Start()
    {
        InvokeRepeating($"spawnEnemy", startingDelay, repeatDelay);
    }

    private void spawnEnemy()
    {
        GameObject enemy = _pool.GetPooledObject();
        
        if (enemy != null) {
            enemy.transform.position = _tr.position;
            enemy.transform.rotation = _tr.rotation;
            enemy.SetActive(true);
            Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
            enemyRb.AddForce(_tr.forward * expusionForce, ForceMode.Impulse);
        }
    }
}