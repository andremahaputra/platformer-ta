using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTransform : MonoBehaviour
{
    public LayerMask targetLayer;

    private MovementHandler target;
    private Vector3 offset;

    void OnTriggerEnter(Collider c)
    {
        if ((targetLayer.value & 1 << c.gameObject.layer) == 1 << c.gameObject.layer)
        {
            target = c.transform.root.gameObject.GetComponent<MovementHandler>();
        }
    }

    void OnTriggerExit(Collider c)
    {
        if ((targetLayer.value & 1 << c.gameObject.layer) == 1 << c.gameObject.layer)
        {
            target = null;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (target == null) return;
        if (!target.isAllowOverridePosition)
            offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 newPos = transform.position + offset;
        if (target.isAllowOverridePosition)
        {
            target.OverrideMovement(newPos);
        }
    }

}
