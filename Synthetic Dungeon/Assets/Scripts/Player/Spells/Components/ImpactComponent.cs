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
        protected Vector3 PlayerPos;
        
        //todo: remove these later
        protected bool IsActive;
                
        public void SpawnProjectile(Vector3 spawnPoint, Vector3 origin)
        {
            var obj = Instantiate(this, spawnPoint, Quaternion.identity);
            obj.IsActive = true;
            obj.PlayerPos = origin;
        }

        public void Update()
        {
            if (IsActive)
            {
                float delta = Time.deltaTime;
                _lifeTime -= delta;

                if (_lifeTime < 0)
                {
                    DestroyProjectile();
                }

                Vector3 dir = transform.position - PlayerPos;
                dir.y = 0;
                dir = dir.normalized;

                //transform.rotation = Quaternion.LookRotation(dir);

                transform.position += delta * 15.0f * dir;
            }
        }
        
        protected virtual void OnHit(Enemy enemy)
        {
            
        }

        protected virtual void DestroyProjectile()
        {
            IsActive = false;
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