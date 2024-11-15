using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum PlayerControlType
    {
        Player1 = 1,
        Player2 = 2
    }
    
     public PlayerControlType playerControl;  // Dropdown to choose between Player1 or Player2

    private float speed = 20f;
    private float turnSpeed =45;

    // Horizontal and Vertical Inputs
    private float horizontalInput;
    private float forwardInput;

    public Camera thirdPersonCamera;
    public Camera driverCamera;
    private KeyCode switchKey = KeyCode.Alpha1; // Key to toggle between cameras


    // Player-specific input
    private  string horizontalInputName;  // Input axis for horizontal movement
    private  string verticalInputName;    // Input axis for vertical movement

    void Start()
    {
        // Based on the selected player control type, set the input axes
        if (playerControl == PlayerControlType.Player1)
        {
            horizontalInputName = "Horizontal1";
            verticalInputName = "Vertical1";
            switchKey = KeyCode.Alpha1;  // Camera toggle for Player 1
        }
        else if (playerControl == PlayerControlType.Player2)
        {
            horizontalInputName = "Horizontal2";
            verticalInputName = "Vertical2";
            switchKey = KeyCode.Alpha2;  // Camera toggle for Player 2
        }
    }
    void Update()
    {
        // Getting player inputs
        horizontalInput = Input.GetAxis(horizontalInputName);
        forwardInput = Input.GetAxis(verticalInputName);

        // Move the car forward based on vertical input
        transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed*horizontalInput);


                // Check for key press
        if (Input.GetKeyDown(switchKey))
        {
            // Toggle between the two cameras
            if (thirdPersonCamera.gameObject.activeSelf)
            {
                SetActiveCamera(driverCamera);
            }
            else
            {
                SetActiveCamera(thirdPersonCamera);
            }
        }
    }


    void SetActiveCamera(Camera activeCamera)
    {
        // Activate the selected camera and deactivate the other
        thirdPersonCamera.gameObject.SetActive(activeCamera == thirdPersonCamera);
        driverCamera.gameObject.SetActive(activeCamera == driverCamera);
    }

}
