using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour
{
    public Image fadeImage; // Reference to the UI Image used for fading
    public float fadeDuration = 2f; // Duration of each fade in seconds

    void Start()
    {
        // Make sure the Image component is attached
        if (fadeImage == null)
        {
            fadeImage = GetComponent<Image>();
            if (fadeImage == null)
            {
                Debug.LogError("Fader script requires an Image component.");
                return;
            }
        }

        // Set the initial color to fully transparent
        Color initialColor = fadeImage.color;
        initialColor.a = 0f;
        fadeImage.color = initialColor;
    }

    // Call this method to start the fade
    public void StartFade()
    {
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        yield return Fade(0f, 1f); // Fade to black

        // Additional actions after fading to black (if needed)

        yield return new WaitForSeconds(2f); // You can add a delay here if needed

        yield return Fade(1f, 0f); // Fade back to normal

        // Additional actions after fading back to normal (if needed)
    }

    IEnumerator Fade(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color targetColor = startColor;
        targetColor.a = targetAlpha;

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor; // Ensure final color is set accurately
    }
}