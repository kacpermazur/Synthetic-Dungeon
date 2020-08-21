using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class SoundManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private AudioMixer _audioMixer;

        [SerializeField] private SoundClip[] _soundClipsSFX;
        [SerializeField] private SoundClip[] _soundClipsUI;
        [SerializeField] private SoundClip[] _soundClipsMUSIC;
        
        private AudioSource _audioSourceSFX;
        private AudioSource _audioSourceMusic;

        public enum SoundType
        {
            SFX,
            UI,
            MUSIC
        }

        public bool Initialize()
        {
            DontDestroyOnLoad(this);

            if (_audioMixer != null)
            {
                _audioSourceMusic = gameObject.AddComponent<AudioSource>();
                _audioSourceSFX = gameObject.AddComponent<AudioSource>();

                _audioSourceMusic.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("Music")[0];
                _audioSourceSFX.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("SFX")[0];
                
                return true;
            }
            
            return false;
        }

        public void PlaySound(string name, SoundType type)
        {
            SoundClip clip;

            switch (type)
            {
                case SoundType.SFX:
                    clip = Array.Find(_soundClipsSFX, soundClip => soundClip.name == name);
                    SetSoundClipSettings(ref _audioSourceSFX, clip);
                    _audioSourceSFX.Play();
                    break;
                case SoundType.UI:
                    clip = Array.Find(_soundClipsUI, soundClip => soundClip.name == name);
                    SetSoundClipSettings(ref _audioSourceSFX, clip);
                    _audioSourceSFX.Play();
                    break;
                case SoundType.MUSIC:
                    clip = Array.Find(_soundClipsMUSIC, soundClip => soundClip.name == name);
                    SetSoundClipSettings(ref _audioSourceMusic, clip);
                    _audioSourceMusic.Play();
                    break;
                default:
                    GameManager.LogMessage("Sound Manager: Clip Not Found!");
                    return;
            }
        }

        public AudioSource PlaySoundSpatialSFX(string name, GameObject gameObject)
        {
            SoundClip clip = Array.Find(_soundClipsSFX, soundClip => soundClip.name == name);
            AudioSource localAudioSource = gameObject.GetComponent<AudioSource>();

            if (localAudioSource == null)
            {
                localAudioSource = gameObject.AddComponent<AudioSource>();
            }

            SetSoundClipSettings(ref localAudioSource, clip);
            localAudioSource.Play();

            return localAudioSource;
        }
        
        private void SetSoundClipSettings(ref AudioSource source, SoundClip clip)
        {
            source.clip = clip.clip;
            source.loop = clip.loop;
            source.volume = clip.volume;
            source.spatialBlend = clip.spacialBlend;
        }
    }
}