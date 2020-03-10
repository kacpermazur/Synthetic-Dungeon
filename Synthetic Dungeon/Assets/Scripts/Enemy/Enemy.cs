using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Data;
using Enemy.Data;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        private EnemyManager _enemyManager;
        
        private EnemyData _enemyData;

        private int _maxHealth;
        private int _currentHealth;

        private int _maxMana;
        private int _currentMana;

        private int _toughness;
        private int _magicPower;

        //todo: Make A State machine later
        private enum State
        {
            PATROL,
            ATTACK,
            DEAD
        }
        private State _state;

        public void Spawn(EnemyManager enemyManager, Transform spawnPosition, CoreData coreData, EnemyData enemyData)
        {
            _enemyManager = enemyManager;
            _enemyData = enemyData;
            
            transform.position = spawnPosition.position;

            _maxHealth = coreData.health;
            _maxMana = coreData.mana;
            _toughness = coreData.toughness;
            _magicPower = coreData.magicPower;

            SetupProperties();
        }

        public virtual void MoveTowardsTarget(Transform target)
        {
            Vector3 targetVector = target.position - transform.position;
            float distance = Mathf.Abs(targetVector.magnitude);

            transform.rotation = Quaternion.LookRotation(targetVector,Vector3.forward);

            if (distance >= 0.5f)
            {
                transform.position += _enemyData.movementSpeed * Time.deltaTime * targetVector.normalized;
            }
        }

        public virtual void TakeDamage(int damage)
        {
            int dmg = (damage - _toughness < 1) ? 0 : damage;
            _currentHealth -= dmg;

            if (_currentHealth <= 0)
            {
                _state = State.DEAD;
                GameManager.LogMessage("Enemy Has Died");
            }
        }

        private void SetupProperties()
        {
            _currentHealth = _maxHealth;
            _currentMana = _maxMana;

            _state = State.ATTACK;
        }
    }
}