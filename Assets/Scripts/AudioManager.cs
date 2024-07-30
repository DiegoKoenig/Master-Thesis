using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private bool musicPaused = false;

    private void Awake()
    {
        // Hiermit wird ermöglicht, dass die Hintergrundmusik auch nach Beenden einer Szene weitergeführt und somit auch der gewählte Lautstärkewert beigehalten wird
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Abspielen der Hintergrundmusik
        PlayMusic("Theme");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Liste der Szenenindizes, in denen die Musik gemutet werden soll
        List<int> muteSceneIndices = new List<int>() { 2, 4, 6, 8, 10 };

        // Überprüft, ob der Index der geladenen Szene in der Liste der zu mutenden Szenenindizes enthalten ist
        if (muteSceneIndices.Contains(scene.buildIndex))
        {
            PauseMusic();
        }
        else
        {
            if (musicPaused)
            {
                ResumeMusic();
                musicPaused = false;
            }
        }
    }

    // Spielt Hintergrundmusik ab
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    // Spielt SFX-Geräusche ab
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PauseMusic()
    {
        musicSource.Pause();
        musicPaused = true;
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}