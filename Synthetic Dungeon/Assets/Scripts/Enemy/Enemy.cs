using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Data;
using Enemy.Data;
using Player.Spells.Components;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour, IOnExecute
    {
        private EnemyManager _enemyManager;
        private EnemyData _enemyData;

        private int _maxHealth;
        private int _currentHealth;

        private int _maxMana;
        private int _currentMana;

        private int _toughness;
        private int _magicPower;

        private List<EffectComponent> _effectComponents;
        private Transform _target;

        //todo: Make A State machine later
        private enum State
        {
            PATROL,
            ATTACK,
            DEAD
        }
        private State _state;

        public void Initialize(EnemyManager enemyManager, CoreData coreData, EnemyData enemyData)
        {
            _enemyManager = enemyManager;
            _enemyData = enemyData;

            _maxHealth = coreData.health;
            _maxMana = coreData.mana;
            _toughness = coreData.toughness;
            _magicPower = coreData.magicPower;

            SetupProperties();
        }

        public void OnExecute()
        {
            MoveTowardsTarget(_target);
        }

        public void Spawn(Vector3 spawnPosition, Transform target)
        {
            _target = target;
            transform.position = spawnPosition;
        }
        
        public void ApplyEffect(EffectComponent effectComponent)
        {
            
        }

        public virtual void MoveTowardsTarget(Transform target)
        {
            Vector3 targetVector = target.position - transform.position;
            float distance = Mathf.Abs(targetVector.magnitude);

            transform.rotation = Quaternion.LookRotation(targetVector, Vector3.up) * Quaternion.Euler(0, -90, 0);

            if (distance >= _enemyData.distanceToPlayer)
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
                DisableThis();
            }
        }

        private void DisableThis()
        {
            _state = State.DEAD;
            _target = null;

            _enemyManager.RemoveFromActive(this);
            gameObject.SetActive(false);
        }

        private void SetupProperties()
        {
            _currentHealth = _maxHealth;
            _currentMana = _maxMana;

            _state = State.ATTACK;
        }
    }
}