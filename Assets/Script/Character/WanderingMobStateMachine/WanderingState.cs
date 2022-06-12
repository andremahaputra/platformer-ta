using DG.Tweening;
using UnityEngine;

public class WanderingState : State
{
    private StateMachine controller;
    private Vector3 targetPos;

    private Vector3 beginPos, endPos;

    public WanderingState(StateMachine controller, Vector3 beginPosition, Vector3 endPosition)
    {
        this.controller = controller;
        this.targetPos = beginPosition;
        this.beginPos = beginPosition;
        this.endPos = endPosition;
    }

    public override void OnEnter() { }

    public override void OnExit() { }

    public override void OnUpdate()
    {
        Debug.DrawLine(beginPos, beginPos + Vector3.up * 10f, Color.green);
        Debug.DrawLine(endPos, endPos + Vector3.up * 10f, Color.red);

        var dir = targetPos - controller.transform.position;
        Debug.DrawLine(controller.transform.position + Vector3.up * 15, controller.transform.position + Vector3.up * 15 + dir.normalized * 10, Color.blue);

        var distance = Vector3.Distance(controller.transform.position, targetPos);
        controller.transform.position += dir.normalized * 5 * Time.deltaTime;

        Debug.DrawLine(controller.transform.position + Vector3.up * 15, targetPos + Vector3.up * 15, Color.yellow);
        controller.transform.rotation = Quaternion.Lerp (controller.transform.rotation, Quaternion.LookRotation(dir.normalized), 5 * Time.deltaTime);
        if (distance < 5f)
        {
            if (targetPos == beginPos) targetPos = endPos;
            else targetPos = beginPos;
        }
        base.OnUpdate();
    }
}