using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenuAttribute(fileName = "Player_Properties_", menuName = "Data/Player_Properties")]
    public class PlayerData : ScriptableObject
    {
        [Header("Properties")] 
        public float movementSpeed;
        public float rotationSpeed;
        public float attackSpeed;
        
        [Header("Stats")] 
        public float health;
        public float mana;
        public float toughness;
    }
}