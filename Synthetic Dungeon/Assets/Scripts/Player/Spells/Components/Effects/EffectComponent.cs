using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    public abstract class EffectComponent : ScriptableObject
    {
        public Sprite icon;
        public float Duration = 2f;
        [ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]public Color Color;
        
        public virtual void Tick(Enemy enemy)
        {
            
        }
    }
}