using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Input Event", menuName = "ScriptableObject/Input Event")]
public class InputChannel : ScriptableObject, IInputChannel
{
    public event IInputChannel.MoveDelegate OnMove;
    public event IInputChannel.JumpDelegate OnJump;
    public event IInputChannel.CrouchDelegate OnCrouch;
    public event IInputChannel.AttackDelegate OnAttack;

    public void Move(InputContext ctx, Vector2 v) 
    {
        OnMove?.Invoke(ctx, v);
    }

    public void Jump(InputContext ctx)
    {
        OnJump?.Invoke(ctx);
    }

    public void Crouch(InputContext ctx) { 
        OnCrouch?.Invoke (ctx);
    }

    public void Attack(InputContext ctx) { 
        OnAttack?.Invoke(ctx);
    }
}
