using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    private Vector3 currentMovement;
    private bool isJumping = false;
    private bool isMovePressed = false;
    private bool isJumpPressed = false;
    private bool isAttackPressed = false;


    private float initialJumpVelocity;
    private float gravity = -9.8f;
    private float groundedGravity = -0.05f;


    [Header("Configuration")]
    [SerializeField] private CharacterStatus status;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float maxJumpHeight = 1f;
    [SerializeField] private float maxJumpTime = 0.5f;


    [Header("Required Component")]
    public CharacterController controller;
    public Animator anim;
    [SerializeField, SerializeReference] private InputContainer inputChannel;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        // Should Inject this

        if (inputChannel != null)
        {
            inputChannel.OnMove += OnMoveListener;
            inputChannel.OnJump += OnJumpListener;
            inputChannel.OnCrouch += OnCrouchListener;
            inputChannel.OnAttack += OnAttackListener;
        }

        SetupJumpVariables();
    }

    void OnDisable()
    {
        inputChannel.OnMove -= OnMoveListener;
        inputChannel.OnJump -= OnJumpListener;
        inputChannel.OnCrouch -= OnCrouchListener;
        inputChannel.OnAttack -= OnAttackListener;
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
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
        }
        else
        {
            isJumping = false;
        }

        anim.SetBool("IsJumping", isJumping);
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

    void OnAttackListener(InputContext ctx)
    {
        if (ctx.status == InputStatus.PRESSED)
        {
            isAttackPressed = true;
        }
        else
        {
            isAttackPressed = false;
        }

        anim.SetBool("IsAttacking", isAttackPressed);
    }
}

