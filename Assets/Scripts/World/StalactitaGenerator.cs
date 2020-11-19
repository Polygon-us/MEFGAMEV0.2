﻿using System.Collections.Generic;
using UnityEngine;

public class StalactitaGenerator : MonoBehaviour
{
    #pragma warning disable CS0649
    #pragma warning disable CS0414

    [SerializeField]
    Transform[] pointToSpawn;
    [SerializeField]
    int amountToSpawn;

    List<Stalactita> stalactites;

    private void Awake()
    {
        stalactites = new List<Stalactita>();
    }

    private void Start()
    {
        SpawnStalcktitas();
    }

    private void SpawnStalcktitas()
    {
        List<Vector3> points = new List<Vector3>();

        foreach (Transform point in pointToSpawn)
            points.Add(point.position);

        for (int i = 0; i < amountToSpawn; i++)
        {
            int index = Random.Range(0, points.Count);

            Vector3 point = points[index];

            points.RemoveAt(index);

            GameObject stalactita = Singleton<Stalactites>.instance.GetPooleObject();

            if (stalactita != null)
            {
                stalactites.Add(stalactita.GetComponent<Stalactita>());

                stalactita.transform.position = point;

                stalactita.SetActive(true);
            }
        }
    }
}