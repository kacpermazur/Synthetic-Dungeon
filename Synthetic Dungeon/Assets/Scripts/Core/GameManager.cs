using Player;
using Enemy;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static readonly string Name = typeof(GameManager).Name;

        private static GameManager _instance;

        [Header("Managers")]
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private EnemyManager _enemyManager;
        
        public static GameManager Instance => _instance;
        public UIManager UiManager => _uiManager; 
        public PlayerManager PlayerManager => _playerManager;
        public EnemyManager EnemyManager => _enemyManager;

        //todo: Move this out later
        private bool _isPlayerActive;
        private bool _isEnemyManagerActive;

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

        private void Update()
        {
            if (_isPlayerActive)
            {
                _playerManager.OnExecute();
            }

            if (_isEnemyManagerActive)
            {
                _enemyManager.OnExecute();
            }
        }

        private void Initialize()
        {

            if (!_uiManager.Initialize())
            {
                LogMessage("Error: Please Reference UIManager!", MessageType.ALERT);
            }

            _isPlayerActive = _playerManager.Initialize();
            if (!_isPlayerActive)
            {
                LogMessage("PlayerManager not initialized!", MessageType.ALERT);
            }
            
            _isEnemyManagerActive = _enemyManager.Initialize();
            if (!_enemyManager)
            {
                LogMessage("EnemyManager not initialized!", MessageType.ALERT);
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