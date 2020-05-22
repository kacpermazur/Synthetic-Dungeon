using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Data;
using Enemy.Data;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour, IInitializable, IOnExecute
    {
        
        [SerializeField] private GameObject[] enemyTypes;

        [SerializeField] private List<Enemy> _enemies;
        [SerializeField] private Transform[] spawnPoints;
        
        public bool Initialize()
        {
            _enemies = new List<Enemy>();
            
            //SpawnEnemy(enemyTypes[0], spawnPoints[0]);
            //SpawnEnemy(enemyTypes[0], spawnPoints[1]);
            
            return true;
        }

        public void OnExecute()
        {
            if (_enemies.Count != 0)
            {
                foreach (var enemy in _enemies)
                {
                    enemy.OnExecute();
                }
            }
            
        }

        public void RemoveFromPool(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        private void SpawnEnemy(GameObject type, Transform transform)
        {
            var instance = Instantiate(type, transform.position, transform.rotation);
            Enemy e = instance.GetComponent<Enemy>();

            e.Initialize();
            _enemies.Add(e);
        }
    }
}