using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] protected bool useTrigger = false;
    [SerializeField] protected bool destroyAfterHit = false;
    [SerializeField] protected LayerMask targetLayer;

    public virtual int DamageAmount { get; protected set; }

    void OnCollisionEnter(Collision c)
    {
        if (useTrigger) return;
        ApplyDamage(c.gameObject);
    }

    protected void ApplyDamage(GameObject c)
    {
        if ((targetLayer.value & 1 << c.gameObject.layer) == 1 << c.gameObject.layer)
        {
            if (destroyAfterHit) Destroy(this.gameObject);

            var handler = c.gameObject.GetComponentInParent<DamageReceiverHandler>();
            if (handler == null) return;

            handler.TakeDamage(this);
        }
    }
}
