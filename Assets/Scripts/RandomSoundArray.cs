using UnityEngine;

public class SimpleRandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource; // Make it public for manual assignment

    void Start()
    {
        // Check if an audio source is manually assigned
        if (audioSource == null)
        {
            // If not assigned, try to get the AudioSource component from the same GameObject
            audioSource = GetComponent<AudioSource>();

            // If still null, add an AudioSource component to the GameObject
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        PlayRandomAudio();
    }

    void PlayRandomAudio()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];
            audioSource.clip = randomClip;
            audioSource.Play();

            // Invoke the method again for the next random play
            Invoke("PlayRandomAudio", Random.Range(15f,25f)); // Adjust the time between plays
        }
        else
        {
            Debug.LogError("No audio clips assigned to the array!");
        }
    }
}