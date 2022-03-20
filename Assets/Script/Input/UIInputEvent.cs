using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputEvent : MonoBehaviour
{
    [SerializeField, SerializeReference] InputContainer channel;
  
    public void OnMoveRightPressed()
    {
        channel.Move(new InputContext(InputStatus.PRESSED), Vector2.right);
    }

    public void OnMoveRightReleased()
    {
        channel.Move(new InputContext(InputStatus.RELEASED), Vector2.right);
    }

    public void OnMoveLeftPressed()
    {
        channel.Move(new InputContext(InputStatus.PRESSED), Vector2.left);
    }

    public void OnMoveLeftReleased()
    {
        channel.Move(new InputContext(InputStatus.RELEASED), Vector2.left);
    }

    public void OnJumpPressed()
    {
        channel.Jump(new InputContext(InputStatus.PRESSED));
    }

    public void OnJumpReleased()
    {
        channel.Jump(new InputContext(InputStatus.RELEASED));
    }

    public void OnCrouchPressed()
    {
        channel.Crouch(new InputContext(InputStatus.PRESSED));
    }

    public void OnCrouchReleased()
    {
        channel.Crouch(new InputContext(InputStatus.RELEASED));
    }

    public void OnAttackPressed()
    {
        channel.Attack(new InputContext(InputStatus.PRESSED));
    }

    public void OnAttackReleased()
    {
        channel.Attack(new InputContext(InputStatus.RELEASED));
    }
}
