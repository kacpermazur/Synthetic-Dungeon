using UnityEngine;

namespace Player.Spells.Components
{
    [CreateAssetMenu(menuName = "Spells/Impact/Damage")]
    public class ImpactComponentDamage : ImpactComponent
    {
        [SerializeField] private int damage = 5;
        public override void OnHit(Enemy.Enemy enemy)
        {
            enemy.TakeDamage(damage);
        }
    }
}