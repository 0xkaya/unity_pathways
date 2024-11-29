using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{

    public enum PlayerControlType
    {
        Player1 = 1,
        Player2 = 2
    }
    
     public PlayerControlType playerControl;  // Dropdown to choose between Player1 or Player2

    [SerializeField]private float horsePower = 20f;
    [SerializeField]private float turnSpeed =45;

    // Horizontal and Vertical Inputs
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody playerRb;

    public Camera thirdPersonCamera;
    public Camera driverCamera;
    private KeyCode switchKey; // Key to toggle between cameras


    // Player-specific input
    private  string horizontalInputName;  // Input axis for horizontal movement
    private  string verticalInputName;    // Input axis for vertical movement

    // Car on the Ground
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Player UI
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    void Awake()
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
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        GetInputs();
        if (IsOnGround()){
            MovePlayer();
        }
        ChangeCamera();
    }


    private void GetInputs(){
        // Getting player inputs
        horizontalInput = Input.GetAxis(horizontalInputName);
        forwardInput = Input.GetAxis(verticalInputName);
    }
    private void Update(){
        speed = Mathf.Round(playerRb.velocity.magnitude*2.37f);
        speedometerText.SetText("Speed: "+speed + "mph");

        rpm = Mathf.Round((speed % 30)*40);
        rpmText.SetText("RPM: "+ rpm);
    }    
    void ChangeCamera()
    {
            // Check for key press
        if (Input.GetKeyDown(switchKey))
        {
            // Toggle between the two cameras
            if (thirdPersonCamera.gameObject.activeSelf)
            {
                Debug.Log("Toggle 1");
                SetActiveCamera(driverCamera);
            }
            else
            {
                Debug.Log("Toggle 2");
                SetActiveCamera(thirdPersonCamera);
            }
        }    
    }
    void MovePlayer(){

        // Move the car forward based on vertical input
        playerRb.AddRelativeForce(Vector3.forward*horsePower*forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed*horizontalInput);
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            Debug.Log("on the ground");
            return true;
        } else
        {
            Debug.Log("not on the ground");
            return false;
        }
    }

    void SetActiveCamera(Camera activeCamera)
    {
        // Activate the selected camera and deactivate the other
        thirdPersonCamera.gameObject.SetActive(activeCamera == thirdPersonCamera);
        driverCamera.gameObject.SetActive(activeCamera == driverCamera);
    }

}
