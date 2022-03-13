using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputEvent : MonoBehaviour, IInputEvent
{
    public event IInputEvent.MoveDelegate OnMove;
    public event IInputEvent.JumpDelegate OnJump;
    public event IInputEvent.CrouchDelegate OnCrouch;


    public void OnMoveRightPressed()
    {

        print("pressed.");
        OnMove?.Invoke(new InputContext(InputStatus.PRESSED), Vector2.right);
    }

    public void OnMoveRightReleased()
    {
        print("released.");
        OnMove?.Invoke(new InputContext(InputStatus.RELEASED), Vector2.right);
    }

    public void OnMoveLeftPressed()
    {
        OnMove?.Invoke(new InputContext(InputStatus.PRESSED), Vector2.left);
    }

    public void OnMoveLeftReleased()
    {
        OnMove?.Invoke(new InputContext(InputStatus.RELEASED), Vector2.left);
    }

    public void OnJumpPressed()
    {
        OnJump?.Invoke(new InputContext(InputStatus.PRESSED));
    }

    public void OnJumpReleased()
    {
        OnJump?.Invoke(new InputContext(InputStatus.RELEASED));
    }

    public void OnCrouchPressed()
    {
        OnCrouch?.Invoke(new InputContext(InputStatus.PRESSED));
    }

    public void OnCrouchReleased()
    {
        OnCrouch?.Invoke(new InputContext(InputStatus.RELEASED));
    }
}
