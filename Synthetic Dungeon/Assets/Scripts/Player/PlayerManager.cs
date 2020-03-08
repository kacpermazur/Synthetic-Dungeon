using Core;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour, IInitializable, IOnUpdate
    {
        private PlayerMovement _playerMovement;
        private Transform _transform;
        private Rigidbody _rigidBody;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidBody;
        
        public bool Initialize()
        {
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerMovement = GetComponent<PlayerMovement>();
            
            _playerMovement.Initialize();
            

            return true;
        }

        public void OnUpdate()
        {
            _playerMovement.OnUpdate();
        }
    }
}