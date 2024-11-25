using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;

    private float xRange = 4;
    private float ySpawnPos = -6;

    // Particle Explosion
    public ParticleSystem explosionParticle;


    // Game Manager Updates
    private GameManager gameManager;
    public int pointValue;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(),RandomTorque());
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce(){
        return Vector3.up*Random.Range(minSpeed,maxSpeed);
    }

    float RandomTorque(){
        return Random.Range(-maxTorque,maxTorque);
    }

    Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange,xRange),ySpawnPos);
    }

    
    private void OnMouseDown(){
        if(gameManager.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if(gameObject.CompareTag("Bad")) 
            {
                gameManager.GameOver();
            }
            gameManager.UpdateScore(pointValue);
            
        }
    }

    private void OnTriggerEnter(Collider other){
        
        /*Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")) 
        {
            gameManager.GameOver();
        }*/
    }
}
