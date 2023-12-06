using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeToBlack : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 0.5f;

    private void Start()
    {
        // Make sure the Image component is attached
        if (fadeImage == null)
        {
            fadeImage = GetComponent<Image>();
            if (fadeImage == null)
            {
                Debug.LogError("FadeToBlack script requires an Image component.");
                return;
            }
        }

        // Set the initial color to transparent
        Color initialColor = fadeImage.color;
        initialColor.a = 0f;
        fadeImage.color = initialColor;
    }

    public void StartFadeOut()
    {
        // Start the fade-out coroutine
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color targetColor = fadeImage.color;
        targetColor.a = 1f;

        while (fadeImage.color.a < 1f)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, targetColor, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    // Additional method to reset the fade state if needed
    public void ResetFade()
    {
        StopAllCoroutines(); // Stop any ongoing fade
        Color resetColor = fadeImage.color;
        resetColor.a = 0f;
        fadeImage.color = resetColor;
    }
}