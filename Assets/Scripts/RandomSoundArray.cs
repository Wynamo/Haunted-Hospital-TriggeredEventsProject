using UnityEngine;

public class SimpleRandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
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
            Invoke("PlayRandomAudio", Random.Range(10f, 20f)); // Adjust the time between plays
        }
        else
        {
            Debug.LogError("No audio clips assigned to the array!");
        }
    }
}