using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{


    private Vector3 currentMovement;
    private bool isMovePressed = false;
    private bool isJumpPressed = false;
    private bool isJumping = false;
    private float initialJumpVelocity;
    private float gravity = -9.8f;
    private float groundedGravity = -0.05f;


    [Header("Configuration")]
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float maxJumpHeight = 1f;
    [SerializeField] private float maxJumpTime = 0.5f;


    [Header("Required Component")]
    public CharacterController controller;
    public Animator anim;


    // Injected Component
    public IInputEvent inputEvent;

    void OnDisable()
    {
        inputEvent.OnMove -= OnMoveListener;
        inputEvent.OnJump -= OnJumpListener;
        inputEvent.OnCrouch -= OnCrouchListener;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        // Should Inject this
        inputEvent = GameObject.FindObjectOfType<UIInputEvent>();

        inputEvent.OnMove += OnMoveListener;
        inputEvent.OnJump += OnJumpListener;
        inputEvent.OnCrouch += OnCrouchListener;

        SetupJumpVariables();
    }


    void Update()
    {
        HandleMovement();
        HandleGravity();
        HandleJump();
    }

    void SetupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void HandleGravity()
    {
        print(controller.isGrounded);
        if (controller.isGrounded) currentMovement.y = groundedGravity;
        else currentMovement.y += gravity * Time.deltaTime;
    }

    void HandleMovement()
    {
        controller.Move(currentMovement * Time.deltaTime);
        if (isMovePressed)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(currentMovement.x, 0, 0), Vector3.up), 8 * Time.deltaTime);
        }

    }

    void HandleJump()
    {
        if (!isJumping && controller.isGrounded && isJumpPressed)
        {
            Debug.Log("Jump!");
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
        }
        else
        {
            isJumping = false;
        }
    }

    void OnMoveListener(InputContext ctx, Vector2 v)
    {
        if (ctx.status == InputStatus.PRESSED)
        {
            currentMovement.x = v.x * moveSpeed;
            anim.SetBool("IsMoving", true);
            isMovePressed = true;
        }
        else
        {
            currentMovement.x = 0;
            isMovePressed = false;
            anim.SetBool("IsMoving", false);
        }
    }

    void OnJumpListener(InputContext ctx)
    {
        if (ctx.status == InputStatus.PRESSED)
        {
            isJumpPressed = true;
        }
        else
        {
            isJumpPressed = false;
        }
    }

    void OnCrouchListener(InputContext ctx)
    {
        if (ctx.status == InputStatus.PRESSED)
        {
            anim.SetBool("IsCrouching", true);
        }
        else
        {
            anim.SetBool("IsCrouching", false);
        }
    }
}

