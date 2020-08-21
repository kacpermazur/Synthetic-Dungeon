using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(BoxCollider))]
    public class PortalTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private bool _homePortal;
        
        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Player"))
            {
                TeleportPlayer(other.GetComponent<Transform>());
            }
        }

        private void TeleportPlayer(Transform playerPos)
        {
            GameManager.LogMessage("Hub: Player has been transported!");
            playerPos.position = _targetTransform.position;

            if (_homePortal)
            {
                GameManager.Instance.DuengonManager.StopDuengon();
            }
            else
            {
                GameManager.Instance.DuengonManager.StartDuengon();
            }
            
        }
    }
}