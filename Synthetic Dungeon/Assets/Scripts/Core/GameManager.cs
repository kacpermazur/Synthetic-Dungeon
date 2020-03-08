using System.Collections;
using System.Collections.Generic;
using Player;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static readonly string Name = typeof(GameManager).Name;

        private static GameManager _instance;
        private PlayerInputActions _playerInputActions;
        
        [Header("Managers")]
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private PlayerManager _playerManager;

        public static GameManager Instance => _instance;
        public UIManager UiManager => _uiManager;
        public PlayerManager PlayerManager => _playerManager;

        public enum MessageType
        {
            MESSAGE,
            ALERT,
            ERROR
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
            
            if(!_uiManager)
            {
                LogMessage("Error: Please Reference UIManager!", MessageType.ALERT);
            }
            else
            {
                _uiManager.Initialize();
            }
            
            if(!_uiManager)
            {
                LogMessage("Error: Please Reference PlayerManager!", MessageType.ALERT);
            }
            else
            {
                _playerManager.Initialize();
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