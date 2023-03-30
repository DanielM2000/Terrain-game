using UnityEngine;
using System.Collections;
using UnityEngine.Audio; // Note this additional Using statement, using UnityEngine.Audio;
public class SoundEffects : MonoBehaviour
{
    public AudioMixerSnapshot inSide;
    public AudioMixerSnapshot outSide;
    void OnTriggerEnter()
    {
        inSide.TransitionTo(2.0f);
    }
    void OnTriggerExit()
    {
        outSide.TransitionTo(2.0f);
    }
}
