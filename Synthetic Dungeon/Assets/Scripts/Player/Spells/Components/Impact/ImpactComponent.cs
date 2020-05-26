using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    
    public class ImpactComponent : ScriptableObject
    {
        public virtual void OnHit(Enemy enemy)
        {
            
        }
    }
}