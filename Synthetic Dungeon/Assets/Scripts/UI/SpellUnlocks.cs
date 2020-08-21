using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [System.Serializable]
    public class SpellUnlocks
    {
        public string name;
        private bool _isUnlocked = false;

        public void UnlockSpell()
        {
            _isUnlocked = true;
        }

        public bool GetStatus()
        {
            return _isUnlocked;
        }
    }
}