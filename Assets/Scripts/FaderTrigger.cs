using UnityEngine;

public class FaderTrigger : MonoBehaviour
{
    public Fader fader; // Reference to the Fader script

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has a specific tag (customize as needed)
        if (other.CompareTag("Player"))
        {
            // Trigger the fader script
            fader.StartFade();
            gameObject.SetActive(false);
        }
    }
}