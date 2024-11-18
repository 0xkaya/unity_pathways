using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Defining the Boundaries
    private float topBound =30;
    private float lowerBound =-10;

    private float sideBound =15.5f ;

    void Update()
    {
        // Destroying the animals when they are out of game boundary
        if(transform.position.z > topBound){
            Destroy(gameObject);
        }else if(transform.position.z < lowerBound){
            FindObjectOfType<SpawnManager>().UpdateLives(-1);
            Destroy(gameObject);
        }else if(transform.position.x > sideBound || transform.position.x < -sideBound)
        {
            FindObjectOfType<SpawnManager>().UpdateLives(-1);
            Destroy(gameObject);
        }
    }
}
