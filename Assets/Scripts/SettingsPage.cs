using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class SettingsPage : MonoBehaviour
{

    public AudioMixer audioMixer;


    void Start()
    {
        
    }
    public void SetSfxVolume (float volume)
    {
        audioMixer.SetFloat("sfx", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        qualityIndex += 3;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
