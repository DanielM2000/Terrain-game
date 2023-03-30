using UnityEngine;

public class AudioVolumeController : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform playerTransform;
    public float maxDistance = 10f; // The maximum distance from the audio source where the volume will be at its minimum.
    public float minDistance = 1f; // The minimum distance from the audio source where the volume will be at its maximum.

    void Start()
    {
        // If the audio source is not set, get it from the object this script is attached to.
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Get the distance between the player and the audio source.
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        // Calculate the new volume for the audio source based on the distance.
        float newVolume = Mathf.InverseLerp(maxDistance, minDistance, distance);

        // Set the volume of the audio source to the new volume.
        audioSource.volume = newVolume;
    }
}
