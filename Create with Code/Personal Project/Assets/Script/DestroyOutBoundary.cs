using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBoundary : MonoBehaviour
{
    private float zBound =10;

    void Update()
    {
        if(transform.position.z< -zBound){
           Destroy(gameObject);
        }

        if(transform.position.z > zBound){
            Destroy(gameObject);
        }
    }

}
