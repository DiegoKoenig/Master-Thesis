using UnityEngine;
using System.Collections.Generic;

public class RandomAudio : MonoBehaviour
{
    public List<AudioClip> audioClips;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomAudio();
    }

    void PlayRandomAudio()
    {
        int randomIndex = Random.Range(0, audioClips.Count);
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
    }
}
