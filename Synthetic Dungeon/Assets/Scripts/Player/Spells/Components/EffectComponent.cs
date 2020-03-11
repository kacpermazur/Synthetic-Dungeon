using UnityEngine;

namespace Player.Spells.Components
{
    using Enemy;
    public abstract class EffectComponent : MonoBehaviour, IInitializable, IOnExecute
    {
        //private 
        
        public bool Initialize()
        {
            return true;
        }

        public void OnExecute()
        {

        }

        public EffectComponent ApplyEffect(Enemy enemy)
        {
            return null;
        }
    }
}