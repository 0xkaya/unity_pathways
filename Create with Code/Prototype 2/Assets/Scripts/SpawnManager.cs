using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public int playerLives = 3; // Starting lives
    public int playerScore = 0; // Starting score
    public TMP_Text _score;
    public TMP_Text _lives;


    // Animal Prefabs to Instantiate
    public GameObject[ ] animalPrefabs; 

    // Spawn Range
    private float spawnRangeX = 10;
    private float spanwPosZ =20;
    private float spawnPosX = 15;
    private float spawnRangeZ = 15;


    // Spawning Start & Interval
    private float startDelay =2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        // Invoking function repeatedly instead of calling in Update Function
        InvokeRepeating("SpawnAnimalFromTop",startDelay,spawnInterval);
        InvokeRepeating("SpawnAnimalFromSides",startDelay,Random.Range(spawnInterval,5));
        // Side Implementation X = -15,  X= 15  Y= 0  Z=Random.Range(0,15)
    }

    public void SpawnAnimalFromTop() 
    {   
        // Random Animal Spawn Function
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spanwPosZ);
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
        animalPrefabs[animalIndex].transform.rotation);

        
    }

    public void SpawnAnimalFromSides() 
    {   
        // Random side selection (-1 for left, 1 for right)
        int side = Random.Range(0, 2) == 0 ? -1 : 1;
        float zPos = Random.Range(2, spawnRangeZ);
        Vector3 spawnPos = new Vector3(side * spawnPosX, 0, zPos);
        
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
        Quaternion.Euler(0, side == 1 ? -90 : 90, 0));
    }

    public void UpdateScore(int points)
    {
        // Update the player's score and display it
        playerScore += points;
        _score.text = $"Score \n {playerScore}";
        Debug.Log($"Score = {playerScore}");
    }

    public void UpdateLives(int change)
    {
        // Update the player's lives and display them
        playerLives += change;
        _lives.text = $"Lives \n {playerLives}" ;
        Debug.Log($"Lives = {playerLives}");

        // Check for game over condition
        if (playerLives <= 0)
        {
            Debug.Log("Game Over");
            CancelInvoke("SpawnAnimalFromSides"); // Stop spawning animals
            CancelInvoke("SpawnAnimalFromTop"); // Stop spawning animals
            Time.timeScale =0;
        }
    }
}
