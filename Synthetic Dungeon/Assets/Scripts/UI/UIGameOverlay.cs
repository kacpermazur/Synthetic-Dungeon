using System.Collections;
using System.Collections.Generic;
using Core;
using Player;
using Player.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIGameOverlay : UIPanel
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Slider manaSlider;
        [SerializeField] private Slider expSlider;

        [SerializeField] private Image _emmisionImage;
        [SerializeField] private Image _impactImage;
        [SerializeField] private Image _effectImage;

        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _infoText;
        [SerializeField] private Animator _animator;
        
        private PlayerManager _playerManager;

        public override bool Initialize()
        {
            if (!healthSlider && !manaSlider && !expSlider && !_emmisionImage && !_impactImage && !_effectImage && !_infoText && !_animator)
            {
                GameManager.LogMessage("UI Manager: Please Reference components in game overlay panel!");
                return false;
            }

            _playerManager = GameManager.Instance.PlayerManager;
            InitializeHealthSlider();
            InitializeManaSlider();
            InitializeExpSlider();
            
            return true;
        }

        public override void Open()
        {
            SetEmmisionImage(_playerManager.SpellSystem.EmissionComponent.icon);
            SetImpactImage(_playerManager.SpellSystem.ImpactComponent.icon);
            SetEffectImage(_playerManager.SpellSystem.EffectComponent.icon);
            
            base.Open();
        }

        public TextMeshProUGUI TextMesh()
        {
            _animator.SetBool("isVisable", true);
            return _infoText;
        }

        public void DisplayTextShow(string message)
        {
            _infoText.text = message;
            _animator.SetBool("isVisable", true);
        }
        
        public void DisplayTextHide()
        {
            _animator.SetBool("isVisable", false);
        }

        public void SetHealth(float health)
        {
            healthSlider.value = health;
        }
        
        public void SetMana(float mana)
        {
            manaSlider.value = mana;
        }
        
        public void SetExp(float exp)
        {
            expSlider.value = exp;
        }

        public void SetLevel(int num)
        {
            _level.text = num.ToString();
        }

        public void SetEmmisionImage(Sprite icon)
        {
            _emmisionImage.sprite = icon;
        }
        
        public void SetImpactImage(Sprite icon)
        {
            _impactImage.sprite = icon;
        }
        
        public void SetEffectImage(Sprite icon)
        {
            _effectImage.sprite = icon;
        }

        private void InitializeHealthSlider()
        {
            healthSlider.maxValue = _playerManager.maxHealth;
            healthSlider.value = _playerManager.currentHealth;
        }
        
        private void InitializeManaSlider()
        {
            manaSlider.maxValue = _playerManager.maxMana;
            manaSlider.value = _playerManager.currentMana;
        }
        
        private void InitializeExpSlider()
        {
            const int maxExp = 100;
            
            expSlider.maxValue = maxExp;
            expSlider.value = _playerManager.exp;
        }
    }
}