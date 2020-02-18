using System.Collections;
using System.Collections.Generic;
using Entity_Core;
using UnityEngine;

namespace Player.Inventory
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        [Header("Item Setup")]
        public string Name;
        public Sprite Icon;
        public ItemType Type;
        public string TempRarity;
       

        [Header("Item Properties")]
        public int Health;
        public int Mana;
        public int Toughness;
        public int AttackPower;
        public int MagicPower;

        [Header("Item Requirements")]
        public int RequiredAttackPower;
        public int RequiredMagicPower;

        public enum ItemType
        {
            WEAPON,
            HAND,
            ARMOR,
            LEGGINGS,
            HELM,
            SHOES,
            GEM
        }
        
    }
}
