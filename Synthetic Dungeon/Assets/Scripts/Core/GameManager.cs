using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static readonly string Name = typeof(GameManager).Name;

        private static GameManager _instance;
        private EntityManager _entityManager;
        private PlayerInputActions _playerInputActions;

        private Vector2 _inputVector2;

        public static GameManager Instance => _instance;
        public EntityManager EntityManager => _entityManager;

        public Vector2 OnMoveVector => _inputVector2;

        public void OnMove(InputValue value)
        {
            _inputVector2 = value.Get<Vector2>();
        }
        
        private void Awake()
        {
            if (!_instance)
            {
                _instance = this;
                _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
                _playerInputActions = new PlayerInputActions();
                LogMessage("GameManager Initialized!");
            }
        }

        private static void LogMessage(string message)
        {
            Debug.Log("<color=Green>" + Name + "</color> : " + message);
        }
    }
}