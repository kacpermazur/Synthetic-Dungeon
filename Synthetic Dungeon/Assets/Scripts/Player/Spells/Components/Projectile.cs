﻿using Core;
using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    public class Projectile : MonoBehaviour
    {
        
        private float _lifeTime = 3f;
        private Vector3 PlayerPos;
        private bool IsActive;

        public void SpawnProjectile(Vector3 spawnPoint, Vector3 origin)
        {
            var obj = Instantiate(this, spawnPoint, Quaternion.identity);

            var inject = obj.gameObject;

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

                transform.position += delta * 15.0f * dir;
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var spellSystem = GameManager.Instance.PlayerManager.SpellSystem;
                
                var enemy = other.GetComponent<Enemy>();
                enemy.ApplyEffect(spellSystem.EffectComponent);
                spellSystem.ImpactComponent.OnHit(enemy, gameObject);

                DestroyProjectile();
            }
        }
        
        private void DestroyProjectile()
        {
            IsActive = false;
            Destroy(gameObject);
        }

    }
}