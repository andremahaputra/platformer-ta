using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputSource : MonoBehaviour, IInputEvent
{
    public event IInputEvent.MoveDelegate OnMove;
    public event IInputEvent.JumpDelegate OnJump;
    public event IInputEvent.CrouchDelegate OnCrouch;
    public event IInputEvent.AttackDelegate OnAttack;

    void Update()
    {
        HandleMoveInput();
        HandleJumpInput();
        HandleCrouchInput();
        HandleAttackInput();
    }

    private void HandleMoveInput()
    {
        var movementInput = Input.GetAxis("Horizontal");
        if (movementInput != 0)
        {
            OnMove?.Invoke(new InputContext(InputStatus.PRESSED), new Vector2(movementInput, 0));
        }
        else
        {
            OnMove?.Invoke(new InputContext(InputStatus.RELEASED), Vector2.zero);
        }


    }

    private void HandleJumpInput()
    {
        var jumpPressed = Input.GetKeyDown(KeyCode.Space);
        if (jumpPressed)
        {
            OnJump?.Invoke(new InputContext(InputStatus.PRESSED));
        }
        else
        {
            OnJump?.Invoke(new InputContext(InputStatus.RELEASED));
        }

    }

    private void HandleCrouchInput()
    {
        var crouchPressed = Input.GetKeyDown(KeyCode.S);
        if (crouchPressed)
        {
            OnCrouch?.Invoke(new InputContext(InputStatus.PRESSED));
        }

        var crouchReleased = Input.GetKeyUp(KeyCode.S);
        if (crouchReleased)
        {
            OnCrouch?.Invoke(new InputContext(InputStatus.RELEASED));
        }


    }


    private void HandleAttackInput() {
        if (Input.GetMouseButton (0)){
            OnAttack?.Invoke(new InputContext(InputStatus.PRESSED));
        }

        if (Input.GetMouseButtonUp(0)) {
            OnAttack?.Invoke(new InputContext(InputStatus.RELEASED));
        }
    }
}