using UnityEngine;
using UnityEngine.Playables;

using UnityEngine;
using UnityEngine.Playables;

public class RandomTimelinePlayer : MonoBehaviour
{
    public PlayableDirector[] timelines;
    public float minTimeBetweenPlays = 5f; // Adjust this value to your desired minimum time
    public float maxTimeBetweenPlays = 10f; // Adjust this value to your desired maximum time

    void Start()
    {
        PlayRandomTimeline();
    }

    void PlayRandomTimeline()
    {
        if (timelines.Length > 0)
        {
            int randomIndex = Random.Range(0, timelines.Length);
            PlayableDirector randomTimeline = timelines[randomIndex];
            randomTimeline.Play();

            // You can add additional logic here if you want to perform actions after playing the timeline.

            // Adjust the minimum and maximum time between plays
            Invoke("PlayRandomTimeline", Random.Range(minTimeBetweenPlays, maxTimeBetweenPlays));
        }
        else
        {
            Debug.LogError("No timelines assigned to the array!");
        }
    }
}