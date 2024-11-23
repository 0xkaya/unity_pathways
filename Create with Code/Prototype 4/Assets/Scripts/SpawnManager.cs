using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public int enemyCount;
    public int waveNumber =1;
    private float spawnRange = 9;
    private int enemyIndex=0;
    private int powerupIndex=0;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0) {
            waveNumber++ ;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }  
    }

    void SpawnEnemyWave(int enemiesToSpawn) {
        for(int i = 0; i< enemiesToSpawn; i++){
            enemyIndex = Random.Range(0,enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex],GenerateSpawnPosition(),enemyPrefab[enemyIndex].transform.rotation);
        }
    }

    void SpawnPowerup(){
        powerupIndex = Random.Range(0,powerupPrefab.Length);
        Instantiate(powerupPrefab[powerupIndex],GenerateSpawnPosition(),powerupPrefab[powerupIndex].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,0,spawnPosZ);
    return randomPos;
    }
}
