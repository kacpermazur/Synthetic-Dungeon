using Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour,IInitializable,IOnUpdate
{
    public bool isActive;

    private Vector2 _onMoveDir;

    public bool Initialize()
    {
        isActive = true;
        return true;
    }

    public void OnUpdate()
    {
        if (isActive)
        {
            Move();
        }
    }

    private void Move()
    {
        GameManager.LogMessage("Bitch just work please", GameManager.MessageType.MESSAGE);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _onMoveDir = context.ReadValue<Vector2>();
    }
}
