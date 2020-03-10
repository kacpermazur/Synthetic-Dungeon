using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using Player.Spells.Components;
using UnityEngine;

namespace Player.Spells
{
    public class SpellSystem : MonoBehaviour, IInitializable, IOnExecute
    {
        [SerializeField] private EmissionComponent emissionComponent;
        [SerializeField] private ImpactComponent impactComponent;
        [SerializeField] private EffectComponent effectComponent;

        private Vector3[] _emissionPoints;

        public bool Initialize()
        {
            return true;
        }
        
        public void OnExecute()
        {
        }

        public void CastSpell()
        {
            _emissionPoints = emissionComponent.GetEmissionShape();
            Vector3 playerPos = GameManager.Instance.PlayerManager.transform.position;

            Debug.Log(playerPos);
            
            foreach (var point in _emissionPoints)
            {
                impactComponent.SpawnProjectile(point, playerPos);
            }
        }

        public void EquipEmissionComponent(EmissionComponent emission)
        {
            emissionComponent = emission;
        }
        
        public void EquipImpactComponent(ImpactComponent impact)
        {
            impactComponent = impact;
        }
        
        public void EquipEffectComponent(EffectComponent effect)
        {
            effectComponent = effect;
        }
    }
}