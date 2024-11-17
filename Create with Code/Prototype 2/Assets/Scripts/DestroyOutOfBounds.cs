using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Defining the Boundaries
    private float topBound =30;
    private float lowerBound =-10;

    void Update()
    {
        // Destroying the objects when they are out of game boundary
        if(transform.position.z > topBound){
            Destroy(gameObject);
        }else if(transform.position.z < lowerBound){
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
