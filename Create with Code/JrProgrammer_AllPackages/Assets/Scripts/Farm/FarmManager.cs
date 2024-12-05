using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public GameObject[] FarmPlots; // Assign plots in Inspector
    public GameObject CropPrefab; // Assign the crop prefab
    public TMP_Text HarvestCounterText;

    private int cropsHarvested = 0;

    private void Start()
    {
        UpdateHarvestCounter();
    }

    public void PlantCrop(GameObject plot)
    {
        // Check if a crop is already planted
        if (plot.transform.childCount > 0) return;

        // Plant a new crop
        GameObject crop = Instantiate(CropPrefab, new Vector3(plot.transform.position.x,plot.transform.position.y+0.15f,plot.transform.position.z), Quaternion.identity, plot.transform);
        crop.GetComponent<Crop>().StartGrowing();
    }

    public void HarvestCrop(GameObject crop)
    {
        cropsHarvested++;
        UpdateHarvestCounter();

        // Remove the crop from the plot
        Destroy(crop);
    }

    private void UpdateHarvestCounter()
    {
        HarvestCounterText.text = "Crops Harvested: " + cropsHarvested;
    }
}
