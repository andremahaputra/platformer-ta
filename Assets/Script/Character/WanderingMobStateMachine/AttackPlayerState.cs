using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using DG.Tweening;

public class AttackPlayerState : State
{
    private StateMachine controller;
    private float aggroRadius;
    private LayerMask targetLayer;
    private Transform aimConstraintTarget;
    private MultiAimConstraint aimConstraint;
    private Transform target;

    public AttackPlayerState(StateMachine controller, Transform targetAimConstraint, MultiAimConstraint aimConstraint, float aggroRadius, LayerMask targetLayer)
    {
        this.controller = controller;
        this.aggroRadius = aggroRadius;
        this.targetLayer = targetLayer;
        this.aimConstraintTarget = targetAimConstraint;
        this.aimConstraint = aimConstraint;
    }

    public override void OnEnter()
    {
        var colls = Physics.OverlapSphere(controller.transform.position, aggroRadius, targetLayer);
        if (colls.Length > 0)
            target = colls.First().transform;
        aimConstraintTarget.position = target.position + (Vector3.up * 15f);

        DOVirtual.Float(0, 1, 1f, (e) =>
        {
            aimConstraint.weight = e;
        });
    }

    public override void OnExit()
    {
        DOVirtual.Float(1, 0, 1f, (e) =>
        {
            aimConstraint.weight = e;
        });
    }

    public override void OnUpdate()
    {

        base.OnUpdate();
    }
}