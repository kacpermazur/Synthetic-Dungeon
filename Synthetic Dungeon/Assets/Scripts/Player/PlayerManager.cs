using Core;
using Player.Data;
using Player.Spells;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerMovement), typeof(SpellSystem))]
    public class PlayerManager : MonoBehaviour, IInitializable, IOnExecute
    {
        private PlayerMovement _playerMovement;
        private SpellSystem _spellSystem;

        [SerializeField] private PlayerData playerData;
        
        private Transform _transform;
        private Rigidbody _rigidBody;

        private bool _enabledControls;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidBody;
        public PlayerData PlayerData => playerData;
        public SpellSystem SpellSystem => _spellSystem;

        public bool Initialize()
        {
            if (playerData == null)
            {
                return false;
            }
            
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerMovement = GetComponent<PlayerMovement>();
            _spellSystem = GetComponent<SpellSystem>();

            _enabledControls = _playerMovement.Initialize() && _spellSystem.Initialize();
            return _enabledControls;
        }

        public void OnExecute()
        {
            if (_enabledControls)
            {
                _playerMovement.OnExecute();
                _spellSystem.OnExecute();
            }
        }

        public void EnableControls()
        {
            _enabledControls = true;
        }
        
        public void DisableControls()
        {
            _enabledControls = false;
        }
        
    }
}