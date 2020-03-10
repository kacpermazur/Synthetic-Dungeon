using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Player.Spells.Components
{
    using Enemy;
    
    public abstract class ImpactComponent : MonoBehaviour
    {
        private float _lifeTime = 3f;
        private Vector3 _playerPos;
        
        
        public void SpawnProjectile(Vector3 spawnPoint, Vector3 playerPos)
        {
            _playerPos = playerPos;
            var obj = Instantiate(this, spawnPoint, Quaternion.identity);
        }

        public void Update()
        {
            float delta = Time.deltaTime;
            _lifeTime -= delta;
            
            if (_lifeTime < 0)
            {
                DestroyProjectile();
            }
            
            Vector3 dir = transform.position - _playerPos;
            dir.y = 0.0f;

            transform.rotation = Quaternion.LookRotation(dir);
            
            transform.position += delta * 15.0f * transform.right;
        }
        
        protected virtual void OnHit(Enemy enemy)
        {
            
        }

        protected virtual void DestroyProjectile()
        {
            Destroy(gameObject);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<Enemy>();
                OnHit(enemy);
            }
        }
    }
}