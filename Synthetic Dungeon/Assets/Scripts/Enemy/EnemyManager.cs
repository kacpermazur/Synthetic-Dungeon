using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour, IInitializable, IOnExecute
    {
        [SerializeField] private EnemyVar[] enemyPool;

        private List<Enemy> _activeEnemies;
        private List<Enemy> _inactiveEnemies;
        
        public bool Initialize()
        {
            GameManager.LogMessage("Enemy Manager Active");
            return true;
        }

        public void OnExecute()
        {

        }

        private void SpawnTestEnemy()
        {
            
        }
    }

    [System.Serializable]
    public struct EnemyVar
    {
        public Enemy enemy;
        public GameObject gameObject;
    }
}