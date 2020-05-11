using System.Collections;
using System.Collections.Generic;
using Camera.Data;
using UnityEngine;

namespace Camera
{
    public class CameraManager : MonoBehaviour, IInitializable, IOnExecute
    {
        [SerializeField] private Transform target;
        [SerializeField] private CameraData data;

        public bool Initialize()
        {
            if (data && target)
            {
                return true;
            }
            
            return false;
        }

        public void OnExecute()
        {
            Vector3 targetPosition = target.position + data.offset;
            Vector3 dampingPos = Vector3.Lerp(transform.position, targetPosition, data.smoothSpeed * Time.deltaTime);

            transform.position = dampingPos;
            transform.LookAt(target);
        }
    }
}