using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputStatus
{
    PRESSED,
    RELEASED,
}

public class InputContext
{
    public InputStatus status;

    public InputContext(InputStatus status)
    {
        this.status = status;
    }
}

public interface IInputEvent
{
    public delegate void MoveDelegate(InputContext ctx, Vector2 vector);
    public delegate void JumpDelegate(InputContext ctx);
    public delegate void CrouchDelegate(InputContext ctx);
    public delegate void AttackDelegate(InputContext ctx);

    public event MoveDelegate OnMove;
    public event JumpDelegate OnJump;
    public event CrouchDelegate OnCrouch;
    public event AttackDelegate OnAttack;

    public void Move(InputContext ctx, Vector2 v);
    public void Jump(InputContext ctx);
    public void Crouch(InputContext ctx);
    public void Attack(InputContext ctx);
}
