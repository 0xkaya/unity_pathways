using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    // Variables for randomization
    private Vector3 randomPosition;
    private float randomScale;
    private float randomRotationSpeed;
    private Color startColor;
    private Color endColor;
    private float colorChangeDuration = 2.0f;
    private float colorChangeTime =0;

    
    void Start()
    {
        // Random Position
        randomPosition = new Vector3(Random.Range(-5,5), Random.Range(1,5), Random.Range(-5,5));
        transform.position = randomPosition;

        // Random Scale
        randomScale = Random.Range(0.5f, 3.0f);
        transform.localScale = Vector3.one * randomScale;
        
        randomRotationSpeed = Random.Range(10.0f, 50.0f); // Random Rotation Speed

        // Color Setup
        Material material = Renderer.material;
        startColor = new Color(Random.value, Random.value, Random.value, Random.Range(0.5f, 1.0f)); // Random start color with opacity
        endColor = new Color(Random.value, Random.value, Random.value, Random.Range(0.5f, 1.0f)); // Random end color with opacity
        material.color = startColor;
    }
    
    void Update()
    {
        // Rotating the cube at the randomized speed 
        transform.Rotate(randomRotationSpeed* Time.deltaTime, 0.0f, randomRotationSpeed* Time.deltaTime);

        // Gradually changing the cube's color over time
        colorChangeTime += Time.deltaTime / colorChangeDuration;
        Renderer.material.color = Color.Lerp(startColor,endColor,Mathf.PingPong(colorChangeTime,1));

    }
}
