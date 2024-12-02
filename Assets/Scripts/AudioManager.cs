using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicEffectGroup;
    [SerializeField] private AudioMixerGroup soundEffectsGroup;

    public static AudioManager Instance;
    public SoundEffects[] sounds;


    public void Awake()
    {
        Instance = this;

        foreach (SoundEffects s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;

            switch (s.audioType)
            {
                case SoundEffects.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = soundEffectsGroup;
                    break;

                case SoundEffects.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicEffectGroup;
                    break;
            }
        }
    }

    public void Stop(string name)
    {
        SoundEffects s = Array.Find(sounds, sound => sound.clipName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound clip not found: " + name);
            return;
        }
        s.source.Stop();
    }


    public void Play(string name)
    {
        SoundEffects s = Array.Find(sounds, sound => sound.clipName == name);
        s.source.Play();
    }

    public void UpdateMixerVolume()
    {
        musicEffectGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        soundEffectsGroup.audioMixer.SetFloat("SoundVolume", Mathf.Log10(AudioOptionsManager.soundEffectolume) * 20);
    }
}
