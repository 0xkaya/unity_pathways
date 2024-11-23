using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Powerups
    {
        None,
        Knockback,
        HomingRockets,
        Smash 
    }

    public Powerups currentPowerup = Powerups.None; // Track the active powerup

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;

    public GameObject powerupIndicator;
    public GameObject projectilePrefab;

    private float powerupStrength = 15.0f;

    public float smashForce = 25.0f; // Maximum force applied by the smash
    public float smashRadius = 12.5f; // Radius of the smash effect
    private bool isSmashing = false;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*speed*forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
        
        if(Input.GetKeyDown(KeyCode.Space) && currentPowerup == Powerups.HomingRockets){

            Rigidbody projictileRb = projectilePrefab.GetComponent<Rigidbody>();
            Debug.Log("Launching Homing Rocket!");
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            //projictileRb.AddForce(focalPoint.transform.forward*powerupStrength/2,ForceMode.Impulse);
        }

                // Smash mechanic (Space key when Smash powerup is active)
        if (Input.GetKeyDown(KeyCode.Space) && currentPowerup == Powerups.Smash && !isSmashing)
        {
            StartCoroutine(PerformSmash());
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Powerup")){
            Destroy(other.gameObject);
            currentPowerup = Powerups.Knockback;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }else if(other.CompareTag("Powerup2")){
            Destroy(other.gameObject);
            currentPowerup = Powerups.HomingRockets;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }else if (other.CompareTag("Powerup3"))
        {
            Destroy(other.gameObject);
            currentPowerup = Powerups.Smash;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }

    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && currentPowerup == Powerups.Knockback)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = (collision.gameObject.transform.position-transform.position);

            Debug.Log("Player Collided with " + collision.gameObject.name +
            "with powerup set to "+ currentPowerup);
            enemyRigidbody.AddForce(awayFromPLayer*powerupStrength,ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        currentPowerup = Powerups.None;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void LaunchHomingRocket()
    {
        Rigidbody projictileRb = projectilePrefab.GetComponent<Rigidbody>();
        Debug.Log("Launching Homing Rocket!");
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        projictileRb.AddForce(projectilePrefab.transform.forward*100,ForceMode.Impulse);
    }

    IEnumerator PerformSmash()
    {
        isSmashing = true;

        // Hop up into the air
        playerRb.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.4f);

        // Smash down onto the ground
        playerRb.AddForce(Vector3.down * 25.0f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);

        // Apply smash force to nearby enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, smashRadius);

        foreach (Collider enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                if (enemyRb != null)
                {
                    Vector3 direction = (enemy.transform.position - transform.position).normalized;
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    float impactForce = Mathf.Lerp(smashForce, 0, distance / smashRadius);

                    enemyRb.AddForce(direction * impactForce, ForceMode.Impulse);
                }
            }
        }

        Debug.Log("Smash performed!");

        isSmashing = false;
    }
}
