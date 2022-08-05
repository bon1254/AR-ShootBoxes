using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer BGMMixer;
    public AudioMixer SFMixer;

    public void BGM_SetLevel(float sliderValue)
    {
        BGMMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SF_SetLevel(float sliderValue)
    {
        SFMixer.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20);
    }
}
