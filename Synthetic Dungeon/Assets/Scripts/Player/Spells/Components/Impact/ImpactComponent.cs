using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    
    public abstract class ImpactComponent : ScriptableObject
    {
        public Sprite icon;
        public virtual void OnHit(Enemy enemy, GameObject gameObject)
        {
            
        }
    }
}