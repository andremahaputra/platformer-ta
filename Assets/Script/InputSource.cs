using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSource : MonoBehaviour {
    public delegate void MoveDelegate (Vector2 vector);
    public static event MoveDelegate OnMovePressed;
    public static event MoveDelegate OnMoveReleased;

    public delegate void JumpDelegate ();
    public static event JumpDelegate OnJumpPressed;
    public static event JumpDelegate OnJumpReleased;

    public delegate void CrouchDelegate ();
    public static event CrouchDelegate OnCrouchPressed;
    public static event CrouchDelegate OnCrouchReleased;


    void Update () {
        var movementInput = Input.GetAxis ("Horizontal");
        if (movementInput != 0) {
            OnMovePressed?.Invoke (new Vector2 (movementInput, 0));
        } else {
            OnMoveReleased?.Invoke (Vector2.zero);
        }


        var jumpPressed = Input.GetKeyDown (KeyCode.Space);
        if (jumpPressed) {
            OnJumpPressed?.Invoke ();
        } else {
            OnJumpReleased?.Invoke ();
        }

        var crouchPressed = Input.GetKeyDown (KeyCode.S);
        if (crouchPressed) {
            OnCrouchPressed?.Invoke ();
        }

       var crouchReleased = Input.GetKeyUp (KeyCode.S);
        if (crouchReleased) {
            OnCrouchReleased?.Invoke ();
        }
    }

}