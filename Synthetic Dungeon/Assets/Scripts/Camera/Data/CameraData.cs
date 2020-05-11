using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera.Data
{
    [CreateAssetMenuAttribute(fileName = "Camera_Data_", menuName = "Data/Camera_Data")]
    public class CameraData : ScriptableObject
    {
        public float smoothSpeed;
        public Vector3 offset;
    }
}