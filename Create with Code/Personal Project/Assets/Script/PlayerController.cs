using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed =5f;
    private Rigidbody playerRb;
    
    private float xBound =10;
    private float zBound =7;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }
    

    void MovePlayer() // Move Player
    {
        // Player Inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward*verticalInput*speed);
        playerRb.AddForce(Vector3.right*horizontalInput*speed);
    }

    void ConstrainPlayerPosition() // Constrain Player's Location
    {
        // Boundary Detection
        if(transform.position.x< -xBound){
            transform.position = new Vector3(-xBound,transform.position.y,transform.position.z);
        }

        if(transform.position.x > xBound){
            transform.position = new Vector3(xBound,transform.position.y,transform.position.z);
        }

        if(transform.position.z< -zBound){
            transform.position = new Vector3(transform.position.x,transform.position.y,-zBound);
            Time.timeScale =0;
            Debug.Log("Game Over!!!");
        }

        if(transform.position.z > zBound){
            transform.position = new Vector3(transform.position.x,transform.position.y,zBound);
        }
    }

    
    void OnCollisionEnter(Collision collision){
        Debug.Log(collision.gameObject.name);
    }
}
