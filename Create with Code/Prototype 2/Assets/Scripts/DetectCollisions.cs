using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int scorePoints = 1; // Points for feeding this animal
    // Detecting Collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            // The player feeds the animal
            //FindObjectOfType<SpawnManager>().UpdateScore(scorePoints);
            GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<SpawnManager>().UpdateLives(-1);
        }
    }


}
