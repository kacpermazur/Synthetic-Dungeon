using Core;
using Player.Data;
using Player.Spells;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerController), typeof(SpellSystem))]
    public class PlayerManager : MonoBehaviour, IInitializable, IOnExecute
    {
        private PlayerController _playerMovement;
        private SpellSystem _spellSystem;

        [SerializeField] private PlayerData playerData;
        
        private Transform _transform;
        private Rigidbody _rigidBody;

        private bool _enabledControls;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidBody;
        public PlayerData PlayerData => playerData;
        public SpellSystem SpellSystem => _spellSystem;

        private float _maxHealth;
        private float _currentHealth;
        
        private float _maxMana;
        private float _currentMana;

        public bool Initialize()
        {
            if (playerData == null)
            {
                return false;
            }
            
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerMovement = GetComponent<PlayerController>();
            _spellSystem = GetComponent<SpellSystem>();

            InitPlayerStats();
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

        public void TakeDamage(float damage)
        {
            float dmg = (damage - playerData.toughness < 1) ? 0 : damage;
            _currentHealth -= dmg;

            if (_currentHealth <= 0)
            {
                //todo: Game Over
            }
        }
        
        public void Heal(float amount)
        {
            _currentHealth += Mathf.Clamp(amount, 0f, _maxHealth- _currentHealth);
        }

        private void InitPlayerStats()
        {
            _maxHealth = playerData.health;
            _currentHealth = _maxHealth;
            
            _maxMana = playerData.mana;
            _currentMana = _maxMana;
        }
        
    }
}