using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    /*
    void OnTriggerEnter(Collider other)
    {
        // Instead of destroying the projectile when it collides with an animal
        //Destroy(other.gameObject); 

        // Just deactivate the food and destroy the animal
        other.gameObject.SetActive(false);
        Destroy(gameObject);
    }*/

    public int scorePoints = 1; // Points for feeding this animal
    // Detecting Collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            // The player feeds the animal
            //FindObjectOfType<SpawnManager>().UpdateScore(scorePoints);
            GetComponent<AnimalHunger>().FeedAnimal(1);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<SpawnManager>().UpdateLives(-1);
        }
    }

}
