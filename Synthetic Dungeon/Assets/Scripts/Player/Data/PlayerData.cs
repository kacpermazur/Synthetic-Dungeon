using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenuAttribute(fileName = "PlayerStats_")]
    public class PlayerData : ScriptableObject
    {
        [Header("Properties")] 
        public float movementSpeed;
        public float rotationSpeed;

        [Header("Statistics")] 
        public int health;
        public int mana;
        public int toughness;
        public int magicPower;
    }
}