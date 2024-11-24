using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] powerups;
    

    // Spawning Enemy Function Parameters
    private int waveCount= 1;
    private float startTime = 2.5f;
    private float repeatRate = 4;

    void Start()
    {
        InvokeRepeating("SpawnEnemy",startTime,repeatRate);
    }

    void Update()
    {
        int enemyCount = FindObjectsOfType<MoveDown>().Length; 
        
        if(enemyCount == 0)
        {
            //SpawnEnemy();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Vector3 spawnPosition = new Vector3(Random.Range(-7.5f,7.5f),0,Random.Range(2f,5f));
            Instantiate(powerups[0],spawnPosition,powerups[0].transform.rotation);
        }

    }

    // Spawn Enemy
    void SpawnEnemy(){

        for(int i=0; i < waveCount; i++){
            int enemyType = Random.Range(0,enemy.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-7f,7f),0,Random.Range(7f,12f));
            Instantiate(enemy[enemyType],spawnPosition,enemy[enemyType].transform.rotation);
        }
        waveCount ++;
    }

}
