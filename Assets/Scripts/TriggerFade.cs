using UnityEngine;

public class TriggerFade : MonoBehaviour
{
    public FadeToBlack FadeScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of the GameObject that should trigger the fade
        {
            FadeScript.StartFadeOut();
        }
    }
}