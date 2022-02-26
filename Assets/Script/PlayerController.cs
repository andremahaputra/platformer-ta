using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour {


    private Vector3 currentMovement;
    
    private bool isMovePressed = false;
    private bool isJumpPressed = false;


    [SerializeField] private float moveSpeed = 10;

    private bool isJumping = false;
    private float initialJumpVelocity;
    [SerializeField] private float maxJumpHeight = 1f;
    [SerializeField] private float maxJumpTime = 0.5f;
    private float gravity = -9.8f;
    private float groundedGravity = -0.05f;

    public CharacterController controller;
    public Animator anim;

    void OnEnable () {
        InputSource.OnMovePressed += movePressed;
        InputSource.OnMoveReleased += moveReleased;
        InputSource.OnJumpPressed += jumpPressed;
        InputSource.OnJumpReleased += jumpReleased;

        InputSource.OnCrouchPressed += crouchPressed;
        InputSource.OnCrouchReleased += crouchReleased;
    }

    void OnDisable () {
        InputSource.OnMovePressed -= movePressed;
        InputSource.OnMoveReleased -= moveReleased;
        InputSource.OnJumpPressed -= jumpPressed;
        InputSource.OnJumpReleased -= jumpReleased;

        InputSource.OnCrouchPressed -= crouchPressed;
        InputSource.OnCrouchReleased -= crouchReleased;
    }

    void Start () {
        controller = GetComponent<CharacterController> ();
        anim = GetComponentInChildren<Animator> ();

        setupJumpVariables ();
    }
    

    void Update () {
        handleMovement ();
        handleGravity ();
        handleJump ();
    }

    void setupJumpVariables () {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow (timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void handleGravity () {
        print (controller.isGrounded);
        if (controller.isGrounded) currentMovement.y = groundedGravity;
        else currentMovement.y += gravity * Time.deltaTime;
    }

    void handleMovement () {
        controller.Move (currentMovement * Time.deltaTime);
    }

    void handleJump () { 
        if (!isJumping && controller.isGrounded && isJumpPressed) {
            Debug.Log ("Jump!");
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
        } else {
            isJumping = false;
        }
    }

    void movePressed (Vector2 v) {
        currentMovement.x = v.x * moveSpeed;
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (new Vector3(v.x, 0, 0), Vector3.up), 8 * Time.deltaTime);
        anim.SetBool ("IsMoving", true);
        isMovePressed = true;
    }

    void moveReleased (Vector2 v) {
        currentMovement.x = 0;
        isMovePressed = false;
        anim.SetBool ("IsMoving", false);
    }

    void jumpPressed () {
        isJumpPressed = true;
    }

    void jumpReleased () {
        isJumpPressed = false;
    }

    void crouchPressed () {
        anim.SetBool ("IsCrouching", true);
    }

    void crouchReleased () { 
        anim.SetBool ("IsCrouching", false);
    }
}