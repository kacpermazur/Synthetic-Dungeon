using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spells.Components
{
    public abstract class EmissionComponent : MonoBehaviour
    {
        public virtual Vector3[] GetEmissionShape(Vector3 origin)
        {
            return null;
        }
    }
}