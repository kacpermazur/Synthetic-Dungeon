﻿using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Enemy.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.AI
{
    public class StateController : MonoBehaviour, IInitializable, IOnExecute
    {
        private float eTime;
        
        private Vector3 _spawnPoint;
        private Vector3 _targetPoint;

        [SerializeField] private State currentState;
        [SerializeField] private State defaultState;
        [SerializeField] private EnemyData _enemyData;
        
        public Vector3 AgentSpawnPoint => _spawnPoint;
        public float nextAttackTime;

        public float ETime => eTime;

        public Vector3 AgentTargetPoint
        {
            get => _targetPoint;
            set => _targetPoint = value;
        }
        public EnemyData AgentData => _enemyData;
        
        public bool Initialize()
        {
            SetPositions();
            nextAttackTime = 0f;
            return true;
        }

        public void OnExecute()
        {
            currentState.UpdateState(this);
            eTime = Time.time;
        }

        public void ChangeEnemyData(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public void ChangeState(State state)
        {
            if (state != defaultState)
            {
                currentState = state;
            }
        }

        private void SetPositions()
        {
            _spawnPoint = transform.position;
            
            Vector3 sp = _spawnPoint;
            float offset = 3f;
                
            Vector3 newPos = new Vector3(Random.Range(sp.x - offset, sp.x + offset), sp.y,
                Random.Range(sp.z - offset, sp.z + offset));

            _targetPoint = newPos;
        }
    }
}