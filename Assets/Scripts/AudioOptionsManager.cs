using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float soundEffectolume { get; private set; }
    public static float musicVolume { get; private set; }

    public Slider audioSlider;
    public Slider musicSlider;


    public void Start()
    {
        if (!PlayerPrefs.HasKey("savedAudioVolume")) { audioSlider.value = 0.5f; }
        else { audioSlider.value = PlayerPrefs.GetFloat("savedAudioVolume"); }

        if (!PlayerPrefs.HasKey("savedMusicVolume")) { musicSlider.value = 0.5f; }
        else { musicSlider.value = PlayerPrefs.GetFloat("savedMusicVolume"); }

        FindObjectOfType<AudioManager>().Play("Music1");


        if (audioSlider.value == 0.0001f) { soundEffectolume = -80; }
        if (musicSlider.value == 0.0001f) { musicVolume = -80; }
    }

    public void OnAudioSliderValueChange(float value)
    {
        soundEffectolume = value;
        PlayerPrefs.SetFloat("savedAudioVolume", audioSlider.value);
        PlayerPrefs.Save();
        AudioManager.Instance.UpdateMixerVolume();
    }

    public void OnMusicSliderValueChance(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("savedMusicVolume", musicSlider.value);
        PlayerPrefs.Save();
        AudioManager.Instance.UpdateMixerVolume();
    }
}
