using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIPanel : MonoBehaviour, IInitializable
    {
        enum UiState
        {
            NONE,
            OPEN,
            CLOSE
        }
        private UiState _state;
        
        public virtual bool Initialize()
        {
            _state = UiState.NONE;
            return true;
        }

        public virtual void Open()
        {
            if (_state == UiState.CLOSE || _state == UiState.NONE)
            {
                _state = UiState.OPEN;
                gameObject.SetActive(true);
            }
        }
        
        public virtual void Close()
        {
            if (_state == UiState.OPEN || _state == UiState.NONE)
            {
                _state = UiState.CLOSE;
                gameObject.SetActive(false);
            }
        }
    }
}