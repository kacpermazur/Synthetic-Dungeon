using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    public abstract class EffectComponent : MonoBehaviour
    {
        public float Duration = 2f;
        
        public virtual void Tick(Enemy enemy)
        {
            
        }
    }
}