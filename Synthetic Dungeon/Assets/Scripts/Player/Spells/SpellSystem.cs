using Core;
using Player.Spells.Components;
using UnityEngine;

namespace Player.Spells
{
    public class SpellSystem : MonoBehaviour, IInitializable
    {
        private PlayerManager _playerManager;

        [SerializeField] private Projectile Projectile;
        
        [Header("Active Components List")]
        [SerializeField] private EmissionComponent emissionComponent;
        [SerializeField] private ImpactComponent impactComponent;
        [SerializeField] private EffectComponent effectComponent;

        [Header("Component List")]
        public EmissionComponent[] EmissionComponents;
        public ImpactComponent[] ImpactComponents;
        public EffectComponent[] EffectComponents;

        public EmissionComponent EmissionComponent => emissionComponent;
        public ImpactComponent ImpactComponent => impactComponent;
        public EffectComponent EffectComponent => effectComponent;

        private Vector3[] _emissionPoints;

        public bool Initialize()
        {
            _playerManager = GameManager.Instance.PlayerManager;
            return true;
        }

        public void CastSpell()
        {
            if (emissionComponent && impactComponent && effectComponent)
            {
                _emissionPoints = emissionComponent.GetEmissionShape(_playerManager.Transform.position);

                foreach (var point in _emissionPoints)
                {
                    Projectile.SpawnProjectile(point, _playerManager.Transform.position);
                }
            }
            else
            {
                GameManager.LogMessage("Spell System: Unable to cast Spell!");
            }
        }

        public void EquipEmissionComponent(EmissionComponent emission)
        {
            emissionComponent = emission;
            GameManager.Instance.UiManager.GameOverlay.SetEmmisionImage(emission.icon);
            GameManager.Instance.UiManager.PanelSkills.SetEmmisionImage(emission.icon);
        }
        
        public void EquipImpactComponent(ImpactComponent impact)
        {
            impactComponent = impact;
            GameManager.Instance.UiManager.GameOverlay.SetImpactImage(impact.icon);
            GameManager.Instance.UiManager.PanelSkills.SetImpactImage(impact.icon);
        }
        
        public void EquipEffectComponent(EffectComponent effect)
        {
            effectComponent = effect;
            GameManager.Instance.UiManager.GameOverlay.SetEffectImage(effect.icon);
            GameManager.Instance.UiManager.PanelSkills.SetEffectImage(effect.icon);
        }
    }
}