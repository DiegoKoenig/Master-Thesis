using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = 0.5f;
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}