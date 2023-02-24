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
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        qualityIndex += 3;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
