using Core;
using Player.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IInitializable, IOnExecute
    {
        [SerializeField] private float _playerRotationOffset = 90f;
        
        private PlayerData _playerData;
        private Vector2 _onMoveDir;

        public bool Initialize()
        {
            _playerData = GameManager.Instance.PlayerManager.PlayerData;
            return true;
        }

        public void OnExecute()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 direction = new Vector3(_onMoveDir.y, 0, -_onMoveDir.x);
            

            if (direction != Vector3.zero)
            {

                transform.rotation = Quaternion.Slerp(transform.rotation,  Quaternion.LookRotation(direction),
                    Time.deltaTime * _playerData.rotationSpeed);
                
                
                transform.position += _playerData.movementSpeed * Time.deltaTime * transform.forward;
            }
        }

        public void OnMove(InputValue value)
        {
            _onMoveDir = value.Get<Vector2>();
        }
        
        public void OnAttack(InputValue value)
        {
            GameManager.Instance.PlayerManager.SpellSystem.CastSpell();
        }
    }
}