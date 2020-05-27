using UnityEngine;

namespace Player.Spells.Components
{
    public abstract class EmissionComponent : ScriptableObject
    {
        public Sprite icon;
        public virtual Vector3[] GetEmissionShape(Vector3 origin)
        {
            return null;
        }
        
    }
}