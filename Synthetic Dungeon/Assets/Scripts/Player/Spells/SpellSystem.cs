using Core;
using Player.Spells.Components;
using UnityEngine;

namespace Player.Spells
{
    public class SpellSystem : MonoBehaviour, IInitializable, IOnExecute
    {
        private PlayerManager _playerManager;

        [SerializeField] private Projectile Projectile;
        
        [SerializeField] private EmissionComponent emissionComponent;
        [SerializeField] private ImpactComponent impactComponent;
        [SerializeField] private EffectComponent effectComponent;

        public EffectComponent EffectComponent => effectComponent;

        private Vector3[] _emissionPoints;

        public bool Initialize()
        {
            _playerManager = GameManager.Instance.PlayerManager;
            return true;
        }
        
        public void OnExecute()
        {
        }

        public void CastSpell()
        {
            _emissionPoints = emissionComponent.GetEmissionShape(_playerManager.Transform.position);
            
            foreach (var point in _emissionPoints)
            {
                Projectile.SpawnProjectile(point, _playerManager.Transform.position);
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