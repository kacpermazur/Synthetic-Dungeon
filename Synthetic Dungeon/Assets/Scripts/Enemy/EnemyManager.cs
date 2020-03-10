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
        [SerializeField] private EnemyVar[] enemyPool;

        [SerializeField] private Transform spawnPoint;
        
        private List<Enemy> _activeEnemies;

        public bool Initialize()
        {
            _activeEnemies = new List<Enemy>();

            for (int i = 0; i < 30; i++)
            {
                SpawnTestEnemy();
            }
            
            
            return true;
        }

        public void OnExecute()
        {
            if (_activeEnemies.Count != 0)
            {
                foreach (var actor in _activeEnemies)
                { 
                    actor.MoveTowardsTarget(GameManager.Instance.PlayerManager.Transform);
                }
            }
        }

        public void RemoveFromActive(Enemy enemy)
        {
            _activeEnemies.Remove(enemy);
            GameManager.LogMessage("Enemy Removed From Active List");
        }

        private void SpawnTestEnemy()
        {
            var instance = Instantiate(enemyPool[0].gameObject);
            var e = instance.GetComponent<Enemy>();
            
            e.Init(this, enemyPool[0].enemyStats , enemyPool[0].enemyProperties);
            
            e.Spawn(new Vector3(Random.Range(-20.0f,20.0f), 1, Random.Range(-20.0f,20.0f)));
            
            _activeEnemies.Add(e);
        }
    }

    [System.Serializable]
    public struct EnemyVar
    {
        public GameObject gameObject;
        public CoreData enemyStats;
        public EnemyData enemyProperties;
    }
}