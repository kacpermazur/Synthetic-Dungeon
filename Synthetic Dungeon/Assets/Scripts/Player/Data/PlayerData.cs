using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenuAttribute(fileName = "Player_Properties_")]
    public class PlayerData : ScriptableObject
    {
        [Header("Properties")] 
        public float movementSpeed;
        public float rotationSpeed;
    }
}