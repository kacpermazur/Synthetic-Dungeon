using System.Collections;
using Core;
using Player.Data;
using Sound;
using Triggers;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour, IInitializable, IOnExecute
    {
        [SerializeField] private float _playerRotationOffset;
        [SerializeField] private OnMeleeDetect _onMeleeDetect;
        
        private PlayerData _playerData;
        private Animator _animator;
        private Vector2 _onMoveDir;

        private bool isAttackedPressed;
        private float nextAttackTime;
        private float nextWalakPlay;

        private Enemy.Enemy _enemy;

        public Enemy.Enemy Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }

        public bool Initialize()
        {
            _animator = GetComponent<Animator>();
            _playerData = GameManager.Instance.PlayerManager.PlayerData;
            
            nextAttackTime = 0;
            nextWalakPlay = 0;

            _onMeleeDetect.Initialize();
            
            if (_animator)
            {
                return true;
            }
            
            return false;
        }

        public void OnExecute()
        {
            float eTime = Time.time;
            
            Movement(eTime);
            Attack(eTime);

        }

        private void Attack(float eTime)
        {
            if (isAttackedPressed)
            {
                isAttackedPressed = false;
                
                if (Time.time > nextAttackTime)
                {
                    GameManager.LogMessage("On Attack");
                    GameManager.Instance.SoundManager.PlaySound("attack", SoundManager.SoundType.SFX);
                    _animator.CrossFade("oh_attack_3", 0.2f);

                    if (_enemy)
                    {
                        _enemy.TakeDamage(8);
                    }
                    
                    nextAttackTime = eTime + _playerData.attackSpeed;
                }
            }
        }

        private void Movement(float eTime)
        {
            Vector3 direction = new Vector3(_onMoveDir.y, 0, -_onMoveDir.x);
            _animator.SetFloat("vertical", 0f, 0.1f, Time.deltaTime);
            
            if (direction != Vector3.zero)
            {
                if (eTime > nextWalakPlay)
                {
                    GameManager.Instance.SoundManager.PlaySound("walk", SoundManager.SoundType.SFX);
                    nextWalakPlay = eTime + 0.75f;
                }
                
                transform.rotation = Quaternion.Slerp(transform.rotation,  Quaternion.LookRotation(direction),
                    Time.deltaTime * _playerData.rotationSpeed);

                transform.position += _playerData.movementSpeed * Time.deltaTime * transform.forward;
                
                _animator.SetFloat("vertical", 1f);
            }
        }

        public void OnMove(InputValue value)
        {
            _onMoveDir = value.Get<Vector2>();
        }
        
        public void OnMagic(InputValue value)
        {
            if (GameManager.Instance.PlayerManager.enabledControls)
            {
                GameManager.LogMessage("On Magic");
                GameManager.Instance.SoundManager.PlaySound("attack", SoundManager.SoundType.SFX);
                _animator.CrossFade("oh_magic_1", 0.2f);
                GameManager.Instance.PlayerManager.SpellSystem.CastSpell();
            }
        }

        public void OnAttack(InputValue value)
        {
            isAttackedPressed = value.isPressed;
        }
        
        private bool _isMagicMenuOpened;
        
        public void OnMagicMenu(InputValue value)
        {
            GameManager.LogMessage("Magic Menu Pressed");

            _isMagicMenuOpened = !_isMagicMenuOpened;

            if (_isMagicMenuOpened)
            {
                GameManager.LogMessage("Magic Menu Opened");
                GameManager.Instance.UiManager.OpenPanel(GameManager.Instance.UiManager.PanelSkills);
            }
            else if(!_isMagicMenuOpened)
            {
                GameManager.LogMessage("Magic Menu Closed");
                GameManager.Instance.UiManager.OpenPanel(GameManager.Instance.UiManager.GameOverlay);
            }
        }

    }
}