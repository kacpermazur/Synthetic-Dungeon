using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Player.Spells.Components;
using UnityEngine;

namespace Player.Spells
{
    public class SpellSystem : MonoBehaviour, IInitializable, IOnExecute
    {
        private EmissionComponent _emissionComponent;
        private ImpactComponent _impactComponent;
        private EffectComponent _effectComponent;

        private Vector3[] _emissionPoints;
        public bool Initialize()
        {
            return true;
        }

        public void OnExecute()
        {
            
        }
    }
}