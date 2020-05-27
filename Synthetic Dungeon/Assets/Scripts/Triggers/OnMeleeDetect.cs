using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Triggers
{
    public class OnMeleeDetect : MonoBehaviour, IInitializable
    {
        private PlayerController _playerController;
        
        public bool Initialize()
        {
            _playerController = transform.parent.GetComponent<PlayerController>();
            return true;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _playerController.Enemy = other.GetComponent<Enemy.Enemy>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _playerController.Enemy = null;
            }
        }
    }
}