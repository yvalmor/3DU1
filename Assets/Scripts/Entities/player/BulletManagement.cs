using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletManagement : MonoBehaviour
{
    public float propulsion = 1f;
    GameObject bullet;
    public ObjectPool pool;

    void Fire(){
        bullet = pool.GetPooledObject(); 
        Console.WriteLine("Bullet fired");
        if (bullet != null) {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * propulsion);
            bullet.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Fire();
        }
    }
}
