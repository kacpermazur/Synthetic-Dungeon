using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class AnimationTester : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float speed;
        [SerializeField] [Range(0, 1)] private float transitionDuration;
        
        [SerializeField] private string animName;
        [SerializeField] private bool play;
        
        private Animator _animator;
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (play)
            {
                speed = 0;
                _animator.CrossFade(animName, transitionDuration);
                play = false;
            }

            _animator.SetFloat("vertical", speed);
        }
    }
}