using System.Collections;
using System.Collections.Generic;
using Enemy.Data;
using UnityEngine;

namespace Enemy.AI
{
    public class StateController : MonoBehaviour, IInitializable, IOnExecute
    {
        private Vector3 _spawnPoint;
        private Vector3 _targetPoint;

        [SerializeField] private State currentState;
        [SerializeField] private State emptyState;
        [SerializeField] private EnemyData _enemyData;
        
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

        public void ChangeState(State state)
        {
            currentState = state;
        }
    }
}