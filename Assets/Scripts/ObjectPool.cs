using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    // Start is called before the first frame update
    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
            if(!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];

        return null;
    }
}
