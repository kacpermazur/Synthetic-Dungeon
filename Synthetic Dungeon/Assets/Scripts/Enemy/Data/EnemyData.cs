using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenuAttribute(fileName = "Enemy_Properties_", menuName = "Data/Enemy_Properties")]
    public class EnemyData : ScriptableObject
    {
        [Header("Combat")] 
        public int damage;
        public int attackRate;

        [Header("Movement")]
        public float movementSpeed;
        public float rotationSpeed;
    }
}