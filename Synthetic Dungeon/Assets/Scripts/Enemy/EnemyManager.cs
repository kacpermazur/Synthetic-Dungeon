using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour, IInitializable, IOnExecute
    {
        [SerializeField] private EnemyVar[] enemyPool;

        [SerializeField] private Transform spawnPoint;
        
        private List<Enemy> _activeEnemies;
        private List<Enemy> _inactiveEnemies;
        
        public bool Initialize()
        {
            GameManager.LogMessage("Enemy Manager Active");
            
            _activeEnemies = new List<Enemy>();
            _inactiveEnemies = new List<Enemy>();
            
            SpawnTestEnemy();
            
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

        private void SpawnTestEnemy()
        {
            var instance = Instantiate(enemyPool[0].gameObject, spawnPoint.position, spawnPoint.rotation);
            var e = instance.GetComponent<Enemy>();
            _activeEnemies.Add(e);
        }
    }

    [System.Serializable]
    public struct EnemyVar
    {
        public Enemy enemy;
        public GameObject gameObject;
    }
}