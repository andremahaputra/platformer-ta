using DG.Tweening;
using UnityEngine;

public class WanderingState : State
{
    private StateMachine controller;
    private Transform targetPosition;
    private Transform beginPosition, endPosition;

    public WanderingState(StateMachine controller, Transform beginPosition, Transform endPosition)
    {
        this.controller = controller;
        this.targetPosition = beginPosition;
        this.beginPosition = beginPosition;
        this.endPosition = endPosition;
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    private Vector3 currentMovement = Vector3.zero;
    public override void OnUpdate()
    {
        var currentPosition = controller.transform.position;
        var distance = Vector3.Distance(currentPosition, targetPosition.position);

        var dir = (currentPosition - targetPosition.position).normalized;
        Debug.Log(dir);
        Debug.Log(targetPosition.position);
        // currentMovement = dir * Time.deltaTime;
        // controller.transform.position += dir;

        if (distance < 1f)
        {
            if (targetPosition == beginPosition)
            {
                targetPosition = endPosition;
            }
            else
            {
                targetPosition = beginPosition;
            }
        }

        base.OnUpdate();
    }
}