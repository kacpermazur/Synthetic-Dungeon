using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenuAttribute(fileName = "Core_Stats_")]
    public class CoreData : ScriptableObject
    {
        [Header("Statistics")] 
        public int health;
        public int mana;
        public int toughness;
        public int magicPower;
    }
}