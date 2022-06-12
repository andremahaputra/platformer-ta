using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[RequireComponent(typeof(DamageReceiverHandler))]
public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private DamageReceiverHandler damageReceiverHandler;
    [SerializeField]
    private CharacterStatus stats;

    [SerializeField]
    private Animator anim;

    private int currentHp;

    public delegate void OnCurrentHealthChangedDelegate(int currentHp);
    public delegate void OnHealthInitializedDelegate(int maxHp, int currentHp);
    public delegate void OnDeadDelegate();

    public event OnCurrentHealthChangedDelegate OnCurrentHealthChanged;
    public event OnHealthInitializedDelegate OnInitialize;
    public event OnDeadDelegate OnDead;

    void Start()
    {
        InitializeHealth();

    }

    void OnEnable()
    {
        if (anim == null) anim = GetComponentInChildren<Animator>();
        if (damageReceiverHandler == null) damageReceiverHandler = GetComponent<DamageReceiverHandler>();

        damageReceiverHandler.OnReceiveDamage += TakeDamage;

    }

    void OnDisable()
    {
        damageReceiverHandler.OnReceiveDamage -= TakeDamage;
    }

    void InitializeHealth()
    {
        currentHp = stats.maxHp;

        OnInitialize?.Invoke(stats.maxHp, stats.maxHp);
    }

    void TakeDamage(DamageSource source)
    {
        currentHp -= source.DamageAmount;
        anim.SetTrigger("TakeDamage");

        OnCurrentHealthChanged?.Invoke(currentHp);
        if (currentHp <= 0)
        {
            currentHp = 0;
            anim.SetBool("IsDead", true);
            OnDead?.Invoke();
        }
    }
}
