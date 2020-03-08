using Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour,IInitializable,IOnUpdate
{
    private bool _isInitialized;
    public bool IsInitialized => _isInitialized;

    private Vector2 _OnMoveDir;

    public void Initialize()
    {
        if (!_isInitialized)
            _isInitialized = true;
    }

    public void OnUpdate()
    {
        if (_isInitialized)
            Move();
    }

    private void Move()
    {
        GameManager.LogMessage(_OnMoveDir.ToString(), GameManager.MessageType.MESSAGE);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _OnMoveDir = context.ReadValue<Vector2>();
    }
}
