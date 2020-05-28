using Core;
using Player.Data;
using Player.Spells;
using Sound;
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

        public bool enabledControls;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidBody;
        public PlayerData PlayerData => playerData;
        public SpellSystem SpellSystem => _spellSystem;

        public float maxHealth;
        public float currentHealth;
        
        public float maxMana;
        public float currentMana;

        public int currentLevel;
        public int exp;

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
            var init = _playerMovement.Initialize() && _spellSystem.Initialize();

            return init;
        }

        public void OnExecute()
        {
            if (enabledControls)
            {
                _playerMovement.OnExecute();
            }
        }

        public void EnableControls()
        {
            GameManager.LogMessage("Controls Enabled");
            enabledControls = true;
        }
        
        public void DisableControls()
        {
            GameManager.LogMessage("Controls Disabled");
            enabledControls = false;
        }

        public void TakeDamage(float damage)
        {
            float dmg = (damage - playerData.toughness < 1) ? 0 : damage;
            currentHealth -= dmg;
            
            GameManager.LogMessage("Player has taken Damage!");
            GameManager.Instance.SoundManager.PlaySound("playerHit", SoundManager.SoundType.SFX);
            GameManager.Instance.UiManager.GameOverlay.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                GameManager.LogMessage("Player Died!");
            }
        }
        
        public void Heal(float amount)
        {
            currentHealth += Mathf.Clamp(amount, 0f, maxHealth - currentHealth);
            GameManager.Instance.UiManager.GameOverlay.SetHealth(currentHealth);
        }

        public void AddExp(int amount)
        {
            exp += amount;

            if (exp <= 100)
            {
                GameManager.LogMessage("PlayerManager: Player Has Leveled UP!");
                currentLevel++;
                exp = 0;
            }
            GameManager.Instance.UiManager.GameOverlay.SetExp(exp);
        }

        private void InitPlayerStats()
        {
            maxHealth = playerData.health;
            currentHealth = maxHealth;
            
            maxMana = playerData.mana;
            currentMana = maxMana;

            currentLevel = 1;
            exp = 0;
        }
        
    }
}