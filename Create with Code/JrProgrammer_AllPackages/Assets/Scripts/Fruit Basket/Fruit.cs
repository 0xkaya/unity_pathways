using UnityEngine;

public class Fruit : MonoBehaviour
{
    private float fallSpeed;

    private void Start()
    {
        fallSpeed = Random.Range(3f, 7f); // Randomize fall speed
    }

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy if it falls off screen
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            // Increment counter in GameManager
            FindObjectOfType<GameManager>().IncrementCounter();
            Destroy(gameObject);
        }
    }
}
