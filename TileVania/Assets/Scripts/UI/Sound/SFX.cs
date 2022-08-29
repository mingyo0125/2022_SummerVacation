using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SFX : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    float sound;

    private void Start()
    {
        audioSlider.value = PlayerPrefs.GetFloat("SFX");
        sound = audioSlider.value;
    }


    public void AudioControl()
    {
        sound = audioSlider.value;

        if(sound == -40f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", sound);
        }
        PlayerPrefs.SetFloat("SFX", audioSlider.value);
    }


    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
