using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class SoundManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private AudioMixer _audioMixer;

        public bool Initialize()
        {
            DontDestroyOnLoad(this);
            return true;
        }

        public void PlaySound(string name)
        {
            
        }

        public void PlaySoundSpatial(string name)
        {
            
        }
    }
}