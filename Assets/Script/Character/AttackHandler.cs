using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackHandler : MonoBehaviour
{
    private bool isAttacking = false;

    [Header("Property")]
    public Projectile projectile;
    public Transform projectileInitialPos;

    [Header("Dependency")]
    public Animator anim;
    public MovementHandler controller;
    public AnimationEventHandler animationEventHandler;
    public InputChannel inputEvent;

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

    private void OnAttackInput(InputContext ctx)
    {
        if (ctx.status == InputStatus.PRESSED)
        {
            if (!isAttacking)
                anim.SetTrigger("Attack");
        }
    }

    private void OnAnimationEvent(string eventName)
    {
        switch (eventName)
        {
            case "begin-attack":
                // Debug.Log("Begin attack");
                isAttacking = true;
                break;
            case "complete-attack":
                // Debug.Log("Complete attack");
                var o = GameObject.Instantiate(projectile, projectileInitialPos.position, Quaternion.identity);
                o.Setup(controller.Forward == Vector2.zero ? Vector2.right : controller.Forward);
                isAttacking = false;
                break;
        }
    }
}
