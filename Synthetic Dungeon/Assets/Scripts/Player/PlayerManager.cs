using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour, IInitializable
    {
        private PlayerMovement _playerMovement;
        private Transform _transform;
        private Rigidbody _rigidBody;

        private bool isInitialized;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidBody;

        public void Initialize()
        {
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerMovement = GetComponent<PlayerMovement>();

            if (_playerMovement)
            {
                _playerMovement.Initialize();
            }
        }
    }
}