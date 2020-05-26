using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    public abstract class EffectComponent : ScriptableObject
    {
        public float Duration = 2f;
        
        public virtual void Tick(Enemy enemy)
        {
            
        }
    }
}