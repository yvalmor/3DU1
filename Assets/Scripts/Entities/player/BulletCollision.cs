using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float bulletDamage = 20f;

    void OnTriggerEnter(Collider other){
        Entity entity = other.GetComponent<Entity>();
        
        if (entity != null) {
            entity.TakeDamage(bulletDamage);
        }
        
        gameObject.SetActive(false);
    }
}
