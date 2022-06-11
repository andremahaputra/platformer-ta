using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;

    public virtual int DamageAmount { get; protected set; }

    void OnCollisionEnter(Collision c)
    {
        if ((targetLayer.value & 1 << c.gameObject.layer) == 1 << c.gameObject.layer)
        {
            Destroy(this.gameObject);

            var handler = c.gameObject.GetComponentInParent<DamageReceiverHandler>();
            if (handler == null) return;
            
            Debug.Log("Invoking damage receiver");
            handler.TakeDamage(this);
        }
    }
}
