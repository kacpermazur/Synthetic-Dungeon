using Core;
using Player.Data;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour, IInitializable, IOnExecute
    {
        private PlayerMovement _playerMovement;

        [SerializeField] private PlayerData playerData;
        
        private Transform _transform;
        private Rigidbody _rigidBody;

        private bool canPlayerMove;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidBody;
        public PlayerData PlayerData => playerData;

        public bool Initialize()
        {
            if (playerData == null)
            {
                return false;
            }
            
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerMovement = GetComponent<PlayerMovement>();

            _playerMovement.Initialize();
            canPlayerMove = true;

            return true;
        }

        public void OnExecute()
        {
            if (canPlayerMove)
            {
                _playerMovement.OnExecute();
            }
        }

        public void EnableControls()
        {
            canPlayerMove = true;
        }
        
        public void DisableControls()
        {
            canPlayerMove = false;
        }
    }
}