using UnityEngine;

public class Plot : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Notify the FarmManager to plant a crop
        FindObjectOfType<FarmManager>().PlantCrop(gameObject);
    }
}
