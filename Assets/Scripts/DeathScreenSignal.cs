using UnityEngine;

public class DeathScreenSignal : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject DeathScreen;
    public GameObject player;

    public void GameOver()
    {

        mainCamera.SetActive(true);
        DeathScreen.SetActive(true);
        player.SetActive(false);
        

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}