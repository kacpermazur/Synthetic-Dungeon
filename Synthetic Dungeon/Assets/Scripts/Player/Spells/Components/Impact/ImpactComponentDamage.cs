using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    public class ImpactComponentDamage : ImpactComponent
    {
        [SerializeField] private int damage = 5;
        protected override void OnHit(Enemy enemy)
        {
            enemy.TakeDamage(damage);
            DestroyProjectile();
        }

    }
}