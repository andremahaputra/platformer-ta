using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Input Event", menuName = "ScriptableObject/Input Event")]
public class InputContainer : ScriptableObject, IInputEvent
{
    public event IInputEvent.MoveDelegate OnMove;
    public event IInputEvent.JumpDelegate OnJump;
    public event IInputEvent.CrouchDelegate OnCrouch;
    public event IInputEvent.AttackDelegate OnAttack;

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
