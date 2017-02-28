using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnObject;
    public float spawnRate = 2.5f;
    private float spawnTime = 0.0f;

    void Update()
    {
        if(Time.time > spawnTime)
        {
            spawnTime = Time.time + spawnRate;
            BetterPool.Spawn(spawnObject, transform.position);
        }
    }
}
