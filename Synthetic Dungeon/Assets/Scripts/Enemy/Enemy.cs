using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Data;
using Enemy.AI;
using Enemy.Data;
using Player.Spells.Components;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour,IInitializable, IOnExecute
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private StateController _stateController;
        
        private float _currentHealth;
        private List<EffectComponent> _effectComponents;
        public bool Initialize()
        {
            _stateController = GetComponent<StateController>();
            _stateController.Initialize();
            
            _enemyManager = GameManager.Instance.EnemyManager;
            _currentHealth = _enemyData.health;

            if (_enemyData)
            {
                return true;
            }
            
            return false;
        }

        public void OnExecute()
        {
            _stateController.OnExecute();
        }
        
        public virtual void TakeDamage(int damage)
        {

            float dmg = (damage - _enemyData.toughness < 1) ? 0 : damage;
            _currentHealth -= dmg;

            if (_currentHealth <= 0)
            {
                _enemyManager.RemoveFromPool(this);
                Destroy(gameObject);
            }
        }
    }
}