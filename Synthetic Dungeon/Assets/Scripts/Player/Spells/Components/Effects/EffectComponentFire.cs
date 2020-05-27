using UnityEngine;
using Core;

namespace Player.Spells.Components
{
    [CreateAssetMenu(menuName = "Spells/Effect/Fire")]
    public class EffectComponentFire : EffectComponent
    {
        public override void Tick(Enemy.Enemy enemy)
        {
            enemy.TakeDamage(1);
        }
    }
}