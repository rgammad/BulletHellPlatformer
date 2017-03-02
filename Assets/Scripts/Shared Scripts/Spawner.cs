using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnRate = 2.5f;
    private float spawnTime = 0.0f;
    private int index = 0;
    public GameObject spawnObject;
    public List<GameObject> spawnPositionList;


    void Update()
    {
        
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + spawnRate;
            BetterPool.Spawn(spawnObject, spawnPositionList[index++].transform.position);
            index = index % spawnPositionList.Count;
        }
    }
}
