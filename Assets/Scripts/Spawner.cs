using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Enemy;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform _tr;

    public ObjectPool _pool;
    public float startingDelay = 0f;
    private static float repeatDelay = 10f;

    private bool activated = true;

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

        while (activated)
        {
            GameObject enemy = _pool.GetPooledObject();
            
            if (enemy is not null)
            {
                enemy.GetComponentInChildren<EnemyEntity>().Reset();
                
                enemy.transform.position = _tr.position;
                enemy.transform.rotation = _tr.rotation;

                enemy.SetActive(true);

                Entity.enemyCounter++;
            }

            yield return new WaitForSeconds(repeatDelay);
        }
    }

    public static void ReduceDelay()
    {
        repeatDelay = repeatDelay * 4 / 5;
    }

    public void Deactivate()
    {
        activated = false;
    }
}