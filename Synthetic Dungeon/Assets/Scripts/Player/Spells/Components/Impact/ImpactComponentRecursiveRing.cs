using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Player.Spells.Components
{
    public class ImpactComponentRecursiveRing : ImpactComponent
    {
        EmissionComponentRing emissionComponentRing;
        ImpactComponentDamage impact;

        private void Awake()
        {
            emissionComponentRing = gameObject.AddComponent<EmissionComponentRing>();
            impact = gameObject.AddComponent<ImpactComponentDamage>();
        }

        protected override void OnHit(Enemy.Enemy enemy)
        { 
            Vector3[] positons = emissionComponentRing.GetEmissionShape(enemy.transform.position);

            foreach (var point in positons)
            {
                impact.SpawnProjectile(point, enemy.transform.position);
            }
        }
    }
}