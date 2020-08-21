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
            
            SpawnEnemy(spawnPoints[0]);
            SpawnEnemy(spawnPoints[1]);
            
            StopAllSound();
            
            
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

        public void ClearAllEnemies()
        {
            int test = _enemies.Count;
            
            if (_enemies.Count > 0)
            {
                for (int i = 0; i < test; i++)
                {
                    _enemies[0].Kill();
                }
            }
        }
        
        public void StartAllSound()
        {
            foreach (var enemy in _enemies)
            {
                enemy.audioSFX.Play();
            }
        }

        public void StopAllSound()
        {
            foreach (var enemy in _enemies)
            {
                enemy.audioSFX.Stop();
            }
        }

        public void SpawnEnemy(Transform transform)
        {
            var instance = Instantiate(enemyTypes[0], transform.position, transform.rotation);
            Enemy e = instance.GetComponent<Enemy>();

            e.Initialize();
            _enemies.Add(e);
        }
        
        public void SpawnEnemy(Vector3 pos, Quaternion rot)
        {
            var instance = Instantiate(enemyTypes[0], pos, rot);
            Enemy e = instance.GetComponent<Enemy>();

            e.Initialize();
            _enemies.Add(e);
        }
        
    }
}