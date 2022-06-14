using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform _tr;

    public ObjectPool _pool;
    public float startingDelay = 0f;
    private static float repeatDelay = 10f;
    public float expusionForce = 1f;

    private void Awake()
    {
        _tr = transform;
    }

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    private IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(startingDelay);

        while (true)
        {
            GameObject enemy = _pool.GetPooledObject();

            if (enemy is not null)
            {
                enemy.transform.position = _tr.position;
                enemy.transform.rotation = _tr.rotation;

                enemy.SetActive(true);
                
                Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                enemyRb.velocity += _tr.forward * expusionForce;
            }

            yield return new WaitForSeconds(repeatDelay);
        }
    }

    public static void ReduceDelay()
    {
        repeatDelay = repeatDelay * 4 / 5;
    }
}