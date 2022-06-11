using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageReceiverHandler))]
public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private DamageReceiverHandler damageReceiverHandler;

    [Header("Configuration")]
    [SerializeField]
    private CharacterStatus stats;

    private int currentHp;
    
    void Awake()
    {
        damageReceiverHandler = GetComponent<DamageReceiverHandler>();
        if (damageReceiverHandler != null) {
            damageReceiverHandler.OnReceiveDamage += TakeDamage;
        }
    }

    void OnDisable() {
        damageReceiverHandler.OnReceiveDamage -= TakeDamage;
    }

    void InitializeHealth() {
        currentHp = stats.maxHp;
    }

    void TakeDamage(DamageSource source) {
        currentHp -= source.DamageAmount;
    }
}
