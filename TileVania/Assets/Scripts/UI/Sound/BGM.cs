using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    float sound;

    private void Start()
    {
        audioSlider.value = PlayerPrefs.GetFloat("Music");
        sound = audioSlider.value;
    }

    public void AudioControl()
    {                 
        sound = audioSlider.value;

        if(sound == -40f)
        {
            masterMixer.SetFloat("Music", -80);
        }
        else
        {
            masterMixer.SetFloat("Music", sound);
        }

        PlayerPrefs.SetFloat("Music", audioSlider.value);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
