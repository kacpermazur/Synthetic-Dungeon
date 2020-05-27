using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(BoxCollider))]
    public class MessageTrigger : MonoBehaviour
    {
        [SerializeField] private MessageComponent messageComponent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                messageComponent.SetMessage(GameManager.Instance.UiManager.GameOverlay.TextMesh());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.UiManager.GameOverlay.DisplayTextHide();
            }
        }
    }
}