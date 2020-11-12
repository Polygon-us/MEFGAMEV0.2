﻿using System.Collections.Generic;
using UnityEngine;

public class TPool : TSingleton<TPool>
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountPool;

    private void Start()
    {
        GameObject obj;

        for (int i = 0; i < amountPool; i++)
        {
            obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooleObject()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        return null;
    }
}