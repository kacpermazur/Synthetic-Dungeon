using System.Collections;
using System.Collections.Generic;
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

        private void SetupProperties()
        {
            _currentHealth = _maxHealth;
            _currentMana = _maxMana;
        }
    }
}