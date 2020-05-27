using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Player;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour, IInitializable
    {
        private List<UIPanel> _uiPanels = new List<UIPanel>();

        [SerializeField] private UIPanelMainMenu panelMainMenu;
        [SerializeField] private UIGameOverlay panelGameOverlay;

        public UIPanelMainMenu MainMenu => panelMainMenu;
        public UIGameOverlay GameOverlay => panelGameOverlay;

        public bool Initialize()
        {
            AddListeners();
            
            _uiPanels.Add(panelMainMenu);
            _uiPanels.Add(panelGameOverlay);

            bool init = panelMainMenu.Initialize() && panelGameOverlay.Initialize();
            
            OpenPanel(panelMainMenu);
            GameManager.Instance.PlayerManager.DisableControls();
            
            return init;
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
            panelMainMenu.onButtonStartClicked += OnButtonStartClicked;
            panelMainMenu.onButtonExitClicked += OnButtonExitClicked;
        }
        
        private void RemoveListeners()
        {
            panelMainMenu.onButtonStartClicked -= OnButtonStartClicked;
            panelMainMenu.onButtonExitClicked -= OnButtonExitClicked;
        }

        private void OnButtonStartClicked()
        {
            GameManager.LogMessage("Start Button Pressed!");
            GameManager.Instance.PlayerManager.EnableControls();
            OpenPanel(panelGameOverlay);
        }

        private void OnButtonExitClicked()
        {
            GameManager.LogMessage("Exit Button Pressed!");
            Application.Quit();
        }
    }
}