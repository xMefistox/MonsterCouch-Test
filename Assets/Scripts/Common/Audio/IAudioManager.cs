using System.Collections;
using UnityEngine;

public interface IAudioManager
{
    void PlayAudio(AudioClip audioClip, float delay = 0.0f);
    void PlayBackground(AudioClip audioClip);
    void SetAudioSource(AudioSource audioSource);
    IEnumerator PlayAudioSourceOnceAndRelease(AudioSource audioSource, float delay);
}