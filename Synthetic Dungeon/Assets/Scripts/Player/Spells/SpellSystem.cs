using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spells
{
    public class SpellSystem : MonoBehaviour, IInitializable, IOnExecute
    {
        public bool Initialize()
        {
            return true;
        }

        public void OnExecute()
        {
            
        }
    }
}