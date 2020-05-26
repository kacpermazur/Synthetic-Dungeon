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

        public StateController StateController => _stateController;

        private float _currentHealth;
        private float _effectTimer;
        
        private EffectComponent _effectComponent;
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

        public virtual void ApplyEffect(EffectComponent effectComponent)
        {
            _effectComponent = effectComponent;

            if (!IsInvoking("TriggerEffect"))
            {
                _effectTimer = effectComponent.Duration;
                InvokeRepeating("TriggerEffect", effectComponent.Duration, 1f);
            }
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

        private void TriggerEffect()
        {
            _effectTimer -= 1f;

            if (_effectTimer <= 0)
            {
                CancelInvoke("TriggerEffect");
            }
            
            _effectComponent.Tick(this);
        }
    }
}