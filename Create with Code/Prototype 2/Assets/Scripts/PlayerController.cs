using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Horizontal & Vertical Inputs
    private float horizontalInput; // Horizontal input parameter
    private float verticalInput; // Horizontal input parameter

    public float speed; // Speed of the player
    private float xRange = 10; // Boundary in X-direction
    private float zRange = 15; // Boundary in X-direction


    // Projectile Object - Pizza
    public GameObject projectilePrefab;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        // Boundary Application -- Limiting the motion in X-direction
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } 
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        } 
        
        // Boundary Application -- Limiting the motion in Z-direction
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }


        // Getting the user input 
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Moving the player horizontally and vertically
        transform.Translate(Vector3.right*horizontalInput*Time.deltaTime*speed);
        transform.Translate(Vector3.forward*verticalInput*Time.deltaTime*speed);
    }
}
