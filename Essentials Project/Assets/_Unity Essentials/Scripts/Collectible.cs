using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed,0);

    }

    private void OnTriggerEnter(Collider other) 
    {
        // Destroy the collectable
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
            Instantiate(onCollectEffect,transform.position,transform.rotation);
            Debug.Log("Collectable Destroyed:  " +gameObject.name);
        }

    }
}
