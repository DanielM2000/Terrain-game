using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioTrigger : MonoBehaviour
{
    public AudioClip splashFX;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(splashFX);
    }
}