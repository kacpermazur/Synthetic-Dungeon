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
                    
                    break;
                case SoundType.UI:
                    break;
                case SoundType.MUSIC:
                    break;
                default:
                    clip = null;
                    GameManager.LogMessage("Sound Manager: Clip Not Found!");
                    return;
            }
        }

        public void PlaySoundSpatial(string name, SoundType type)
        {
            
        }

        public void StopSound(string name, SoundType type)
        {
            SoundClip clip;
            
            switch (type)
            {
                case SoundType.SFX:
                    break;
                case SoundType.UI:
                    break;
                case SoundType.MUSIC:
                    break;
                default:
                    clip = null;
                    GameManager.LogMessage("Sound Manager: Clip Not Found!");
                    return;
            }
        }

        private void SetAudioClipSettings(ref AudioSource source, SoundClip clip)
        {
            source.clip = clip.clip;
            source.loop = clip.loop;
            source.volume = clip.volume;
            source.spatialBlend = clip.spacialBlend;
        }
    }
}