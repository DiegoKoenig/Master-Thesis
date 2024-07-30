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
        // Es werden die gespeicherten Werte für die Lautsprecher-Slider des Optionenmenüs geladen
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
        // Slider-Werte werden in PlayerPrefs gespeichert
        PlayerPrefs.SetFloat(MusicVolumeKey, _musicSlider.value);

        // AudioManager wird neuer Lautstärke-Wert der Hintergrundmusik übergeben
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        // Slider-Werte werden in PlayerPrefs gespeichert
        PlayerPrefs.SetFloat(SFXVolumeKey, _sfxSlider.value);

        // AudioManager wird neuer Lautstärke-Wert der SFX-Geräusche übergeben
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    private void LoadSliderValues()
    {
        // Gespeicherte Slider-Werte werden laden oder es werden die Standardwerte (Mittelwert) verwendet, falls nichts gespeichert wurde
        _musicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
        _sfxSlider.value = PlayerPrefs.GetFloat(SFXVolumeKey, 0.5f);
    }
}
