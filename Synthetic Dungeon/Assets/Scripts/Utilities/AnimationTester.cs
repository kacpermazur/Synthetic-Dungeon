using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class AnimationTester : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float speed;
        
        private Animator _animator;
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            _animator.SetFloat("vertical",speed);
        }
    }
}