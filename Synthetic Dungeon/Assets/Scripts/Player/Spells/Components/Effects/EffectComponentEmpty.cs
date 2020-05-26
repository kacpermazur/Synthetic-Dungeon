using UnityEngine;
using Core;

namespace Player.Spells.Components
{
    [CreateAssetMenu(menuName = "Spells/Effect/Empty")]
    public class EffectComponentEmpty : EffectComponent
    {
        public override void Tick(Enemy.Enemy enemy)
        {
            
        }
    }
}