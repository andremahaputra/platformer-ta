using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackHandler : MonoBehaviour
{
    private bool isAttacking = false;
    private bool isAnimComplete = false;

    [Header("Property")]
    public Projectile projectile;
    public Transform projectileInitialPos;

    [Header("Dependency")]
    public Animator anim;
    public MovementHandler controller;
    public AnimationEventHandler animationEventHandler;
    public InputChannel inputEvent;

    [Header("Configuration")]
    [SerializeField]
    private float fireRate = 0.3f;
    private float fireTimer = 0;


    void OnEnable()
    {
        inputEvent.OnAttack += OnAttackInput;
        animationEventHandler.OnAnimationEvent += OnAnimationEvent;
    }

    void OnDisable()
    {
        inputEvent.OnAttack -= OnAttackInput;
        animationEventHandler.OnAnimationEvent -= OnAnimationEvent;
    }

    private void Reset()
    {
        isAttacking = false;
        isAnimComplete = false;
    }

    private void OnAttackInput(InputContext ctx)
    {
        isAttacking = ctx.status == InputStatus.PRESSED;
        anim.SetBool("IsAttacking", isAttacking);
    }

    private void OnAnimationEvent(string eventName)
    {
        print(eventName);
        switch (eventName)
        {
            case "begin-attack":
                isAnimComplete = false;
                break;
            case "complete-attack":
                isAnimComplete = true;
                break;
        }
    }


    void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        fireTimer += Time.deltaTime;

        if (isAttacking && isAnimComplete && fireTimer > fireRate)
        {
            var o = GameObject.Instantiate(projectile, projectileInitialPos.position, Quaternion.identity);
            o.Setup(controller.Forward);
            fireTimer = 0;
        }
    }
}
