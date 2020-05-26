using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class SoundManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private AudioMixer _audioMixer;

        private AudioSource _audioSourceMusic;
        private AudioSource _audioSourceSFX;
        
        public enum SoundType
        {
            SFX,
            MUSIC,
            UI
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
            
        }

        public void PlaySoundSpatial(string name, SoundType type)
        {
            
        }

        public void StopSound(string name, SoundType type)
        {
            
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