using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamageSource : DamageSource
{
    [SerializeField]
    private int damage;

    public override int DamageAmount { get => damage; protected set => base.DamageAmount = value; }

    void OnTriggerEnter(Collider c) {
        if (!useTrigger) return;
        ApplyDamage(c.gameObject);
    }
}
