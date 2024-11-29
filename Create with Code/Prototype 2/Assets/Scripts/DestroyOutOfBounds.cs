using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float sideBound =15.5f ;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);

        }
        else if(transform.position.z < lowerBound){
            FindObjectOfType<SpawnManager>().UpdateLives(-1);
            Destroy(gameObject);
        }else if(transform.position.x > sideBound || transform.position.x < -sideBound)
        {
            FindObjectOfType<SpawnManager>().UpdateLives(-1);
            Destroy(gameObject);
        }

    }
}
