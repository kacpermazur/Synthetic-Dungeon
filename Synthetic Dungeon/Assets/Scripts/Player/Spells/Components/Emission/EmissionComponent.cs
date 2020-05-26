﻿using UnityEngine;

namespace Player.Spells.Components
{
    public class EmissionComponent : ScriptableObject
    {
        public virtual Vector3[] GetEmissionShape(Vector3 origin)
        {
            return null;
        }
        
    }
}