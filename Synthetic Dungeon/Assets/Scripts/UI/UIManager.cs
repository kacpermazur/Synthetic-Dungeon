using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Player;
using Sound;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour, IInitializable
    {
        private List<UIPanel> _uiPanels = new List<UIPanel>();

        [SerializeField] private UIPanelMainMenu panelMainMenu;
        [SerializeField] private UIGameOverlay panelGameOverlay;
        [SerializeField] private UIPanelSkills panelSkills;

        public UIPanelMainMenu MainMenu => panelMainMenu;
        public UIGameOverlay GameOverlay => panelGameOverlay;
        public UIPanelSkills PanelSkills => panelSkills;

        public bool Initialize()
        {
            AddListeners();
            
            _uiPanels.Add(panelMainMenu);
            _uiPanels.Add(panelGameOverlay);

            bool init = panelMainMenu.Initialize() && panelGameOverlay.Initialize() && panelSkills.Initialize();
            
            OpenPanel(panelMainMenu);
            GameManager.Instance.PlayerManager.DisableControls();

            if (!init)
            {
                GameManager.LogMessage("UI Manager references Failed!");
            }
            
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

            panelSkills.onButtonEmptyClicked += onButtonEmptyClicked;
            panelSkills.onButtonFireClicked += onButtonFireClicked;
            
            panelSkills.onButtonFowardClicked += onButtonFowardClicked;
            panelSkills.onButtonRingClicked += onButtonRingClicked;
            
            panelSkills.onButtonDamageClicked += onButtonDamageClicked;
        }
        
        private void RemoveListeners()
        {
            panelMainMenu.onButtonStartClicked -= OnButtonStartClicked;
            panelMainMenu.onButtonExitClicked -= OnButtonExitClicked;
            
            panelSkills.onButtonEmptyClicked -= onButtonEmptyClicked;
            panelSkills.onButtonFireClicked -= onButtonFireClicked;
            
            panelSkills.onButtonFowardClicked -= onButtonFowardClicked;
            panelSkills.onButtonRingClicked -= onButtonRingClicked;
            
            panelSkills.onButtonDamageClicked -= onButtonDamageClicked;
        }

        private void OnButtonStartClicked()
        {
            GameManager.LogMessage("Start Button Pressed!");
            GameManager.Instance.SoundManager.PlaySound("UIClick", SoundManager.SoundType.UI);
            GameManager.Instance.SoundManager.PlaySound("music", SoundManager.SoundType.MUSIC);
            GameManager.Instance.PlayerManager.EnableControls();
            OpenPanel(panelGameOverlay);
        }

        private void OnButtonExitClicked()
        {
            GameManager.LogMessage("Exit Button Pressed!");
            GameManager.Instance.SoundManager.PlaySound("UIClick", SoundManager.SoundType.UI);
            Application.Quit();
        }

        private void onButtonEmptyClicked()
        {
            GameManager.LogMessage("Empty Effect Selected!");
        }
        
        private void onButtonFireClicked()
        {
            GameManager.LogMessage("Fire Effect Selected!");
        }
        
        private void onButtonFowardClicked()
        {
            GameManager.LogMessage("Foward Emission Selected!");
        }
        
        private void onButtonRingClicked()
        {
            GameManager.LogMessage("Ring Emission Selected!");
        }
        
        private void onButtonDamageClicked()
        {
            GameManager.LogMessage("Damage Impact Selected!");
        }
    }
}