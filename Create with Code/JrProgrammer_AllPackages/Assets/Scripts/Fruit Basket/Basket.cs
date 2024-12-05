using UnityEngine;

public class Basket : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

        transform.Translate(movement);

        // Clamp the basket to the screen bounds
        float screenLimit = 8f; // Adjust based on the screen size
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -screenLimit, screenLimit),
            transform.position.y,
            transform.position.z
        );
    }
}
