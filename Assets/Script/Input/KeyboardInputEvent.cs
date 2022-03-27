using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputEvent : MonoBehaviour
{
    [SerializeField, SerializeReference] InputChannel channel;

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
            channel.Move(new InputContext(InputStatus.PRESSED), new Vector2(movementInput, 0));
        }
        else
        {
            channel.Move(new InputContext(InputStatus.RELEASED), Vector2.zero);
        }
    }

    private void HandleJumpInput()
    {
        var jumpPressed = Input.GetKeyDown(KeyCode.Space);
        if (jumpPressed)
        {
            channel.Jump(new InputContext(InputStatus.PRESSED));
        }
        else
        {
            channel.Jump(new InputContext(InputStatus.RELEASED));
        }

    }

    private void HandleCrouchInput()
    {
        var crouchPressed = Input.GetKeyDown(KeyCode.S);
        if (crouchPressed)
        {
            channel.Crouch(new InputContext(InputStatus.PRESSED));
        }

        var crouchReleased = Input.GetKeyUp(KeyCode.S);
        if (crouchReleased)
        {
            channel.Crouch(new InputContext(InputStatus.RELEASED));
        }


    }

    private void HandleAttackInput() {
        if (Input.GetMouseButton (0)){
            channel.Attack(new InputContext(InputStatus.PRESSED));
        }

        if (Input.GetMouseButtonUp(0)) {
            channel.Attack(new InputContext(InputStatus.RELEASED));
        }
    }
}