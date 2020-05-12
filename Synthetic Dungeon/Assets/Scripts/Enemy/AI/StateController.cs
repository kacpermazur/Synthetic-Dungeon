using System.Collections;
using System.Collections.Generic;
using Enemy.Data;
using UnityEngine;

namespace Enemy.AI
{
    public class StateController : MonoBehaviour, IInitializable, IOnExecute
    {
        private EnemyData _enemyData;
        
        private Vector3 _spawnPoint;
        private Vector3 _targetPoint;
        
        public Vector3 AgentSpawnPoint => _spawnPoint;

        public Vector3 AgentTargetPoint
        {
            get => _targetPoint;
            set => _targetPoint = value;
        }
        public EnemyData AgentData => _enemyData;
        
        public bool Initialize()
        {
            _targetPoint = Vector3.zero;
            return true;
        }

        public void OnExecute()
        {
            
        }
    }
}