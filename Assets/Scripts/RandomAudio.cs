using UnityEngine;
using System.Collections.Generic;

public class RandomAudio : MonoBehaviour
{
    // Ermöglicht das Hinzufügen beliebig vieler Fakten
    public List<AudioClip> audioClips;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomAudio();
    }

    void PlayRandomAudio()
    {
        // Ein zufälliger Index wird generiert, um einen AudioClip aus der Liste zu wählen
        int randomIndex = Random.Range(0, audioClips.Count);

        // Der ausgewählte AudioClip wird dem AudioSource-Clip zugewiesen
        audioSource.clip = audioClips[randomIndex];
        
        // Der AudioClip wird abgespielt
        audioSource.Play();
    }
}
