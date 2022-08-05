using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] ButtonSounds;

    public void ButtonSound01()
    {
        audioSource.clip = ButtonSounds[0];
        audioSource.Play();
    }
}
