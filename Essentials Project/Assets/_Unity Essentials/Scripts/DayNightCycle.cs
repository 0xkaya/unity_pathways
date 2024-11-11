using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Duration of a full day in seconds, editable from the Inspector
    [Tooltip("The number of seconds for a full day cycle.")]
    public float dayDuration = 120f; // Default to 2 minutes

    // Rotation speed of the directional light
    private float rotationSpeed;

    void Start()
    {
        // Calculate rotation speed based on day duration
        rotationSpeed = 360f / dayDuration;
    }

    void Update()
    {
        // Rotate the light around the x-axis at the calculated speed
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
