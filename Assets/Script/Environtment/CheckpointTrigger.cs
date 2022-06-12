using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] protected CheckpointManager manager;
    [SerializeField] private LayerMask targetLayer;

    void Awake()
    {
        manager = GameObject.FindObjectOfType<CheckpointManager>();
    }

    void OnTriggerEnter(Collider c)
    {
        if ((targetLayer.value & 1 << c.gameObject.layer) == 1 << c.gameObject.layer)
        {
            TriggerEvent(c);
        }
    }

    protected virtual void TriggerEvent(Collider c) { }
}
