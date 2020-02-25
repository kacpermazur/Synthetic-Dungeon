using System.Collections;
using System.Collections.Generic;
using UI;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static readonly string Name = typeof(GameManager).Name;

        private static GameManager _instance;
        private PlayerInputActions _playerInputActions;

        [Header("Camera")] 
        [SerializeField] private Camera _camera;
        public Camera GameCamera => _camera;

        [Header("Managers")]
        private EntityManager _entityManager;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private Inventory _inventory;
        
        private Vector2 _inputVector2; //todo: Move this out To InputClass

        public static GameManager Instance => _instance;
        public EntityManager EntityManager => _entityManager;
        public UIManager UiManager => _uiManager;
        public Inventory Inventory => _inventory;
        public enum MessageType
        {
            MESSAGE,
            ALERT,
            ERROR
        }

        public Vector2 OnMoveVector => _inputVector2; //todo: Move this out To InputClass

        public void OnMove(InputValue value)
        {
            _inputVector2 = value.Get<Vector2>(); //todo: Move this out To InputClass
        }
        
        private void Awake()
        {
            if (!_instance)
            {
                _instance = this;
                Initialize();
            }
        }

        private void Initialize()
        {
            _playerInputActions = new PlayerInputActions();
            
            
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            if (!_camera)
            {
                _camera = Camera.main;
            }

            if(!_uiManager)
            {
                LogMessage("Error: Please Reference UIManager!", MessageType.ALERT);
            }
            else
            {
                _uiManager.Initialize();
            }

            if (!_inventory)
            {
                LogMessage("Error: Please Reference Inventory!", MessageType.ALERT);
            }
            else
            {
                _uiManager.Initialize();
            }
        }
        

        public static void LogMessage(string message, MessageType? type = null)
        {
            switch (type)
            {
                case null:
                case MessageType.MESSAGE:
                    Debug.Log("<color=BlueViolet> MESSAGE </color>" + " <color=Green>" + Name + "</color> : " + message);
                    break;
                case MessageType.ALERT:
                    Debug.Log("<color=Gold> ALERT </color>" + " <color=Green>" + Name + "</color> : " + message);
                    break;
                case MessageType.ERROR:
                    Debug.Log("<color=FireBrick> ERROR </color>" + " <color=Green>" + Name + "</color> : " + message);
                    break;
                default:
                    Debug.Log("<color=Red> LOG MESSAGE ERROR! </color>");
                    break;
            }
        }
    }
}