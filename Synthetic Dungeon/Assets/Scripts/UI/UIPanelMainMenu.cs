using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class UIPanelMainMenu : UIPanel
    {
        public UnityAction onButtonStartClicked;
        public UnityAction onButtonExitClicked;
        
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        
        public override bool Initialize()
        {
            if (!startButton && !exitButton)
            {
                GameManager.LogMessage("Button References not Set!");
                return false;
            }
         
            startButton.onClick.AddListener(ButtonStart);
            exitButton.onClick.AddListener(ButtonExit);
            
            return true;
        }

        private void ButtonStart()
        {
            onButtonStartClicked?.Invoke();
        }
        
        private void ButtonExit()
        {
            onButtonExitClicked?.Invoke();
        }
    }
}