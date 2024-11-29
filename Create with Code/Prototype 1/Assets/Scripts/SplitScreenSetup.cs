using UnityEngine;

public class SplitScreenSetup : MonoBehaviour
{
    public Camera fpsCameraP1;  // First-person camera for Player 1
    public Camera tpsCameraP1;  // Third-person camera for Player 1

    public Camera fpsCameraP2;  // First-person camera for Player 2
    public Camera tpsCameraP2;  // Third-person camera for Player 2


    private Rect side1 = new Rect(0, 0, 0.5f, 1);
    private Rect side2  = new Rect(0.5f, 0, 0.5f, 1);


    void Start()
    {
        // Assign screen space to Player 1 cameras
        fpsCameraP1.rect = side1;
        tpsCameraP1.rect = side1;

        // Assign screen space to Player 2 cameras
        fpsCameraP2.rect = side2;
        tpsCameraP2.rect = side2;

        // By default, set third-person cameras as active
        SetActiveCamera(tpsCameraP1, tpsCameraP2);
    }

    // Utility method to set active cameras
    void SetActiveCamera(Camera cameraP1, Camera cameraP2)
    {
        // Activate/deactivate cameras for Player 1
        fpsCameraP1.gameObject.SetActive(cameraP1 == fpsCameraP1);
        tpsCameraP1.gameObject.SetActive(cameraP1 == tpsCameraP1);

        // Activate/deactivate cameras for Player 2
        fpsCameraP2.gameObject.SetActive(cameraP2 == fpsCameraP2);
        tpsCameraP2.gameObject.SetActive(cameraP2 == tpsCameraP2);
    }
}
