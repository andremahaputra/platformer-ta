using System.Linq;
using UnityEngine;
using UnityEngine.Animations.Rigging;

class AggresiveWanderingStateMachine : StateMachine
{
    [SerializeField] HealthHandler healthHandler;
    [SerializeField] Transform aimConstraintTarget;
    [SerializeField] MultiAimConstraint aimConstraint;


    [SerializeField] Transform projectilePos;
    [SerializeField] GameObject projectile;

    
    [SerializeField] Transform beginTransform, endTransform;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float aggroRadius = 10;
    [SerializeField] float ignoreRadius = 10;

    private Collider target = null;
    private Vector3 initialPos;

    void OnEnable() {
        healthHandler.OnDead += Dead;
    }

    void OnDisable() {
        healthHandler.OnDead -= Dead;
    }

    private void Dead(){
        aimConstraint.weight = 0;
        enabled = false;
    }

    protected override void Initialize()
    {
        initialPos = transform.position;
        var attackPlayer = new AttackPlayerState(this, aimConstraintTarget, aimConstraint, aggroRadius, targetLayer, projectilePos, projectile);
        var wandering = new WanderingState(this, beginTransform.position, endTransform.position);


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
        var colls = Physics.OverlapSphere(initialPos, aggroRadius, targetLayer);
        if (colls.Length > 0)
            target = colls.First();

        return target != null;
    }

    private bool CheckIgnoreRadius()
    {
        if (target == null) return true;
        var distance = Vector3.Distance(target.transform.position, initialPos);
        if (distance > ignoreRadius) target = null;
        
        return distance > ignoreRadius;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, .2f);
        Gizmos.DrawSphere(initialPos, aggroRadius);

        Gizmos.color = new Color(0, 204, 0, .2f);
        Gizmos.DrawSphere(initialPos, ignoreRadius);

    }
}