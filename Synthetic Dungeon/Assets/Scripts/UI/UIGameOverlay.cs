using System.Collections;
using System.Collections.Generic;
using Core;
using Player.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIGameOverlay : UIPanel
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Slider manaSlider;

        [SerializeField] private Image _emmisionImage;
        [SerializeField] private Image _impactImage;
        [SerializeField] private Image _elementImage;

        private PlayerData _playerData;

        public override bool Initialize()
        {
            if (!healthSlider && !manaSlider && !_emmisionImage && !_impactImage && !_elementImage)
            {
                GameManager.LogMessage("UI Manager: Please Reference components in game overlay panel!");
                return false;
            }

            _playerData = GameManager.Instance.PlayerManager.PlayerData;
            InitializeHealthSlider();
            InitializeManaSlider();
            
            return true;
        }

        public void SetHealth(float health)
        {
            healthSlider.value = health;
        }
        
        public void SetMana(float mana)
        {
            manaSlider.value = mana;
        }

        public void SetEmmisionImage(Sprite icon)
        {
            _emmisionImage.sprite = icon;
        }
        
        public void SeImpactImage(Sprite icon)
        {
            _impactImage.sprite = icon;
        }
        
        public void SetElementImage(Sprite icon)
        {
            _elementImage.sprite = icon;
        }

        private void InitializeHealthSlider()
        {
            healthSlider.maxValue = _playerData.health;
            healthSlider.value = _playerData.health;
        }
        
        private void InitializeManaSlider()
        {
            manaSlider.maxValue = _playerData.mana;
            manaSlider.value = _playerData.mana;
        }
    }
}