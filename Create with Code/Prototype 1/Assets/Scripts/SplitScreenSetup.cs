using UnityEngine;

public class SplitScreenSetup : MonoBehaviour
{
    public Camera player1Camera;  // Camera for Player 1
    public Camera player2Camera;  // Camera for Player 2


    void Start()
    {
        // Set Player 1 Camera (Left Half of the Screen)
        player1Camera.rect = new Rect(0, 0, 0.5f, 1);

        // Set Player 2 Camera (Right Half of the Screen)
        player2Camera.rect = new Rect(0.5f, 0, 0.5f, 1);
    }
}
