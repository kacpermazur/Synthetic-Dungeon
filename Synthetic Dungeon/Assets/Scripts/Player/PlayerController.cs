using System.Collections;
using Core;
using Player.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour, IInitializable, IOnExecute
    {
        [SerializeField] private float _playerRotationOffset;
        
        private PlayerData _playerData;
        private Animator _animator;
        private Vector2 _onMoveDir;
        
        public bool Initialize()
        {
            _animator = GetComponent<Animator>();
            _playerData = GameManager.Instance.PlayerManager.PlayerData;

            if (_animator)
            {
                return true;
            }
            
            return false;
        }

        public void OnExecute()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 direction = new Vector3(_onMoveDir.y, 0, -_onMoveDir.x);
            
            _animator.SetFloat("vertical", 0f, 0.1f, Time.deltaTime);
            
            if (direction != Vector3.zero)
            {
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
            GameManager.LogMessage("On Magic");
            _animator.CrossFade("oh_magic_1", 0.2f);
            GameManager.Instance.PlayerManager.SpellSystem.CastSpell();
        }

        public void OnAttack(InputValue value)
        {
            GameManager.LogMessage("On Attack");
            _animator.CrossFade("oh_attack_3", 0.2f);
        }

    }
}