using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BulletManagement : MonoBehaviour
{
    [Range(10f, 200f)] public float propulsion;
    public float resetDistance = 100f;
    public ObjectPool pool;
    public Transform cameraTransform;

    private int firedBullets = 0;

    private void Fire()
    {
        if (firedBullets >= 20)
            return;
        
        GameObject bullet = pool.GetPooledObject();

        if (bullet is null) return;
        
        bullet.transform.position = cameraTransform.position;
        bullet.transform.rotation = cameraTransform.rotation;

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        
        bulletRigidbody.velocity += cameraTransform.forward * propulsion;
        bullet.SetActive(true);

        firedBullets++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();
        
        if (Input.GetButtonDown("Fire2"))
            Reload();
    }

    private void Reload()
    {
        foreach (var poolObject in pool.pooledObjects.Where(poolObject =>
                     poolObject.activeSelf &&
                     Vector3.Distance(poolObject.transform.position, transform.position) >= resetDistance))
        {
            poolObject.SetActive(false);
            firedBullets--;
        }
    }

    public void PutBulletBack()
    {
        firedBullets--;
    }
}