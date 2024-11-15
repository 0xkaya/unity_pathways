using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    private float propellerSpeed = 450f; 

    void Update()
    {
       transform.Rotate(Vector3.forward * Time.deltaTime*propellerSpeed); 
    }
}
