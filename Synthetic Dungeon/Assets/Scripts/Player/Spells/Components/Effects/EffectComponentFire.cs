using UnityEngine;
using Core;

namespace Player.Spells.Components
{
    [CreateAssetMenu(menuName = "Spells/Effect/Fire")]
    public class EffectComponentFire : EffectComponent
    {
        public override void Tick(Enemy.Enemy enemy)
        {
            GameManager.LogMessage("fire tick");
            enemy.TakeDamage(1);
        }
    }
}