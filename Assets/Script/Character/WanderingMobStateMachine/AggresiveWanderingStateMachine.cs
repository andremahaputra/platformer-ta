using System.Linq;
using UnityEngine;
using UnityEngine.Animations.Rigging;

class AggresiveWanderingStateMachine : StateMachine
{
    [SerializeField] Transform beginPos, endPos;
    [SerializeField] Transform aimConstraintTarget;
    [SerializeField] MultiAimConstraint aimConstraint;

    [SerializeField] LayerMask targetLayer;
    [SerializeField] float aggroRadius = 10;
    [SerializeField] float ignoreRadius = 10;

    Collider target = null;

    protected override void Initialize()
    {
        var attackPlayer = new AttackPlayerState(this, aimConstraintTarget, aimConstraint, aggroRadius, targetLayer);
        var wandering = new WanderingState(this, beginPos, endPos);


        wandering.transitions.Add(new Transition
        {
            nextState = attackPlayer,
            shouldNext = CheckAggroRadius,
        });

        attackPlayer.transitions.Add(new Transition
        {
            nextState = wandering,
            shouldNext = CheckIgnoreRadius,
        });

        states.Add(wandering);
        states.Add(attackPlayer);
    }

    private bool CheckAggroRadius()
    {
        var colls = Physics.OverlapSphere(transform.position, aggroRadius, targetLayer);
        if (colls.Length > 0)
            target = colls.First();

        return target != null;
    }

    private bool CheckIgnoreRadius()
    {
        if (target == null) return true;
        var distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > ignoreRadius) target = null;
        
        return distance > ignoreRadius;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, .2f);
        Gizmos.DrawSphere(transform.position, aggroRadius);

        Gizmos.color = new Color(0, 204, 0, .2f);
        Gizmos.DrawSphere(transform.position, ignoreRadius);

    }
}