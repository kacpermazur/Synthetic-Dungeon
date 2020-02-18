using System.Collections;
using System.Collections.Generic;
using Entity_Core;
using UnityEngine;

namespace Player.Inventory
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private StatsData _statsData;

        public string Name => _name;
        public StatsData StatsData => _statsData;

        public abstract string InfoText();
    }
}
