using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float minTimeBetweenPlays = 5f;
    public float maxTimeBetweenPlays = 10f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayRandomAudio", Random.Range(minTimeBetweenPlays, maxTimeBetweenPlays));
    }

    void PlayRandomAudio()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];
            audioSource.clip = randomClip;
            audioSource.Play();

            Invoke("PlayRandomAudio", Random.Range(minTimeBetweenPlays, maxTimeBetweenPlays));
        }
        else
        {
            Debug.LogError("No audio clips assigned to the array!");
        }
    }
}