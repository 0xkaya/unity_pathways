using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Animal Prefabs to Instantiate
    public GameObject[ ] animalPrefabs; 

    // Spawn Range
    private float spawnRangeX = 10;
    private float spanwPosZ =20;


    // Spawning Start & Interval
    private float startDelay =2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        // Invoking function repeatedly instead of calling in Update Function
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    public void SpawnRandomAnimal() 
    {   
        // Random Animal Spawn Function
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spanwPosZ);
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
        animalPrefabs[animalIndex].transform.rotation);
    }
}
