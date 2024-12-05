using UnityEngine;

public class Crop : MonoBehaviour
{
    public float GrowTime = 5f; // Time to grow in seconds
    private bool isGrown = false;

    private void Start()
    {
        // Start growing immediately
        StartGrowing();
    }

    public void StartGrowing()
    {
        Invoke(nameof(Grow), GrowTime);
    }

    private void Grow()
    {
        isGrown = true;
        GetComponent<Renderer>().material.color = Color.yellow; // Change color to indicate growth
    }

    private void OnMouseDown()
    {
        if (isGrown)
        {
            // Notify the FarmManager to harvest
            FindObjectOfType<FarmManager>().HarvestCrop(gameObject);
        }
    }
}
