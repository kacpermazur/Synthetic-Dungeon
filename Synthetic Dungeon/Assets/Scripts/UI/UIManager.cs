using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Player;
using Player.Spells;
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

        private SpellSystem _spellSystem;

        public bool Initialize()
        {
            AddListeners();
            
            _uiPanels.Add(panelMainMenu);
            _uiPanels.Add(panelGameOverlay);
            _uiPanels.Add(panelSkills);

            bool init = panelMainMenu.Initialize() && panelGameOverlay.Initialize() && panelSkills.Initialize();
            
            OpenPanel(panelMainMenu);
            GameManager.Instance.PlayerManager.DisableControls();

            _spellSystem = GameManager.Instance.PlayerManager.SpellSystem;

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
            _spellSystem.EquipEffectComponent(_spellSystem.EffectComponents[0]);
        }
        
        private void onButtonFireClicked()
        {
            GameManager.LogMessage("Fire Effect Selected!");
            Debug.Log(_spellSystem.EffectComponents[1]);
            _spellSystem.EquipEffectComponent(_spellSystem.EffectComponents[1]);
        }
        
        private void onButtonFowardClicked()
        {
            GameManager.LogMessage("Foward Emission Selected!");
            _spellSystem.EquipEmissionComponent(_spellSystem.EmissionComponents[0]);
        }
        
        private void onButtonRingClicked()
        {
            GameManager.LogMessage("Ring Emission Selected!");
            _spellSystem.EquipEmissionComponent(_spellSystem.EmissionComponents[1]);
        }
        
        private void onButtonDamageClicked()
        {
            GameManager.LogMessage("Damage Impact Selected!");
            _spellSystem.EquipImpactComponent(_spellSystem.ImpactComponents[0]);
        }
    }
}