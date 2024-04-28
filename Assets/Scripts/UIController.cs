using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

    private void Start()
    {
        // Beim Start die gespeicherten Werte für die Slider laden
        LoadSliderValues();
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        // Slider-Wert speichern
        PlayerPrefs.SetFloat(MusicVolumeKey, _musicSlider.value);
        // AudioManager den neuen Musik-Lautstärke-Wert übergeben
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        // Slider-Wert speichern
        PlayerPrefs.SetFloat(SFXVolumeKey, _sfxSlider.value);
        // AudioManager den neuen SFX-Lautstärke-Wert übergeben
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    private void LoadSliderValues()
    {
        // Gespeicherte Slider-Werte laden, oder Standardwerte verwenden, falls nichts gespeichert wurde
        _musicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
        _sfxSlider.value = PlayerPrefs.GetFloat(SFXVolumeKey, 0.5f);
    }
}
