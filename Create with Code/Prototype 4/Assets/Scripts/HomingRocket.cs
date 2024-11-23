using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 5.0f;
    public GameObject target; // The rocket's target

    void Start()
    {
        // Find the nearest enemy as the target
        target = FindClosestEnemy();
    }

    void Update()
    {
        if (target != null)
        {
            // Rotate the rocket toward the target
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Move the rocket toward the target
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            // Destroy the rocket if no target is found
            Destroy(gameObject);
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                closest = enemy;
                minDistance = distance;
            }
        }

        return closest;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the rocket and deal damage if it hits an enemy
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Homing Rocket hit " + other.name);
            Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the enemy
        }
    }
}
