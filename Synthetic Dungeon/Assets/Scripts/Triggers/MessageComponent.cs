using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Triggers
{
    [CreateAssetMenu(menuName = "Text/Message_")]
    public class MessageComponent : ScriptableObject
    {
        [Header("Message")]
        public string text;
        
        [Header("Font Settings")]
        public int fontSize = 36;
        public Color color = Color.white;
        public TextAlignmentOptions textAlignmentOptions;
        
        public void SetMessage(TextMeshProUGUI textMesh)
        {
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.alignment = textAlignmentOptions;
        }
    }
}
