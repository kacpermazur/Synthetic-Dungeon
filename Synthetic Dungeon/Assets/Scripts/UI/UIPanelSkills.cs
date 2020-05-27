using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class UIPanelSkills : UIPanel
    {
        public UnityAction onButtonEmptyClicked;
        public UnityAction onButtonFireClicked;
        
        public UnityAction onButtonFowardClicked;
        public UnityAction onButtonRingClicked;
        
        public UnityAction onButtonDamageClicked;
        
        [Header("Spell Active Icons")]
        [SerializeField] private Image _emmisionImage;
        [SerializeField] private Image _impactImage;
        [SerializeField] private Image _effectImage;
        
        [Header("Spell Emission")]
        [SerializeField] private Button _emptyButton;
        [SerializeField] private Button _fireButton;

        [Header("Spell Impact")]
        [SerializeField] private Button _fowardButton;
        [SerializeField] private Button _ringButton;

        [Header("Spell Effects")]
        [SerializeField] private Button _damgeButton;

        public override bool Initialize()
        {
            _emptyButton.onClick.AddListener(ButtonEmpty);
            _fireButton.onClick.AddListener(ButtonFire);
            
            _fowardButton.onClick.AddListener(ButtonFoward);
            _ringButton.onClick.AddListener(ButtonRing);
            
            _damgeButton.onClick.AddListener(ButtonDamage);
            
            return true;
        }

        private void ButtonEmpty()
        {
            onButtonEmptyClicked?.Invoke();
        }
        
        private void ButtonFire()
        {
            onButtonFireClicked?.Invoke();
        }
        
        private void ButtonFoward()
        {
            onButtonFowardClicked?.Invoke();
        }
        
        private void ButtonRing()
        {
            onButtonRingClicked?.Invoke();
        }
        
        private void ButtonDamage()
        {
            onButtonDamageClicked?.Invoke();
        }
    }
}