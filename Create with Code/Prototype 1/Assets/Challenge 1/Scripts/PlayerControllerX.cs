using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 10;
    private float rotationSpeed =45;
    private float verticalInput;
    private float horizontalInput;


    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed*Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime* verticalInput);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime* horizontalInput);

    }
}
