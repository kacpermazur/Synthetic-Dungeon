using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour, IInitializable
    {
        private List<UIPanel> _uiPanels = new List<UIPanel>();

        public bool Initialize()
        {
            AddListeners();
            return true;
        }

        public void OpenPanel(UIPanel panel)
        {
            foreach (var uiPanel in _uiPanels)
            {
                uiPanel.Close();
            }
            panel.Open();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            
        }
        
        private void RemoveListeners()
        {
            
        }
    }
}